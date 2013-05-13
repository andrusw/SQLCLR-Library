//------------------------------------------------------------------------------
// Taken from MSDN Article http://msdn.microsoft.com/magazine/dn198246
// Original Source Code: http://archive.msdn.microsoft.com/mag201305Graph
// From KSharkey and James McCaffrey
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void ShortestPath(SqlInt64 startNode, SqlInt64 endNode, SqlInt32 maxNodesToCheck, out SqlString pathResult, out SqlDouble distResult)
    {
        Dictionary<long, double> distance = new Dictionary<long, double>();// curr shortest distance (double) from startNode to (key) node
        Dictionary<long, long> previous = new Dictionary<long, long>();// predecessor values to construct the actual path when done
        Dictionary<long, bool> beenAdded = new Dictionary<long, bool>();// has node been added to the queue yet? Once added, we don't want to add again

        long startNodeAsLong = (long)startNode;
        long endNodeAsLong = (long)endNode;
        int maxNodesToCheckAsInt = (int)maxNodesToCheck;

        MyPriorityQueue PQ = new MyPriorityQueue();

        //initialize start node
        distance[startNodeAsLong] = 0.0;// distance from start node to itself is 0
        previous[startNodeAsLong] = -1;// -1 is the code for undefined.
        PQ.Enqueue(new NodeDistance(startNodeAsLong, 0.0));// the queue holds distance information because Enqueue and Dequeue need it to keep queue ordered by priority. alt approach would be to store only node IDs and then do a distance lookup
        beenAdded[startNodeAsLong] = true;

        double alt = 0.0; //'test distance'

        try
        {
            while (PQ.Count() > 0 && beenAdded.Count < maxNodesToCheckAsInt)
            {
                NodeDistance u = PQ.Dequeue();// node with shortest distance from start
                if (u.nodeID == endNode)
                    break;// found the target end node

                //fetch all neighbors (v) of u

                List<Tuple<long, double>> neighbors = new List<Tuple<long, double>>();
                neighbors = FetchNeighbors(u.nodeID);


                foreach (var v in neighbors)// if there are no neighbors, this loop will exit immediately
                {
                    if (beenAdded.ContainsKey(v.Item1) == false)//first appearance of node v
                    {
                        distance[v.Item1] = double.MaxValue; //stand-in for infinity
                        previous[v.Item1] = -1; //undefined
                        PQ.Enqueue(new NodeDistance(v.Item1, double.MaxValue));//maxValue is a dummy value
                        beenAdded[v.Item1] = true;
                    }

                    //alt = distance[u.nodeID] + 1.0;  // if all edge weights are just hops can simplify to this
                    alt = distance[u.nodeID] + v.Item2;  // alt = dist(start-to-u) + dist(u-to-v), so alt is total distance from start to v

                    if (alt < distance[v.Item1])  // is alt a new, shorter distance from start to v?
                    {
                        distance[v.Item1] = alt;
                        previous[v.Item1] = u.nodeID;
                        PQ.ChangePriority(v.Item1, alt);  // this will change the distance/priority 
                    }
                }
            }

            // extract the shortest path as a string from the previous[] array
            pathResult = "NOTREACHABLE";   // default result string
            distResult = -1.0;      // distance result defaults to -1 == unreachable

            if (distance.ContainsKey(endNodeAsLong) == true)  // endNode was encountered at some point in the algorithm
            {
                double sp = distance[endNodeAsLong];  // shortest path distance
                if (sp != double.MaxValue)       // we have a reachable path
                {
                    pathResult = "";
                    long currNode = endNodeAsLong;
                    while (currNode != startNodeAsLong)  // construct the path as  semicolon delimited string
                    {
                        pathResult += currNode.ToString() + ";";
                        currNode = previous[currNode];
                    }
                    pathResult += startNode.ToString();   // tack on the start node
                    distResult = sp;                      // the distance result
                }
            }
        }
        catch (Exception ex) // typically Out Of Memory or a Command TimeOut
        {
            pathResult = ex.ToString();
            distResult = -1.0;
        }
    }

    private static List<Tuple<long, double>> FetchNeighbors(long nodeID)
    {
        List<Tuple<long,double>> neighbors = new List<Tuple<long,double>>();

        SqlCommand cmd = new SqlCommand("SELECT toNode, edgeWeight FROM tblGraph WHERE fromNode = @nodeID");
        cmd.Parameters.Add("@nodeID",SqlDbType.BigInt);
        cmd.Parameters["@nodeID"].Value = nodeID;

        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            conn.Open();
            cmd.Connection = conn; //cmd.CommandTimeout can be set here

            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while(sdr.Read())
                {
                    neighbors.Add(new Tuple<long,double>(long.Parse(sdr[0].ToString()), double.Parse(sdr[1].ToString())));
                }
            }
        }

        return neighbors;
    }
}



public class NodeDistance
{
    public long nodeID;
    public double distance;

    public NodeDistance(long nodeID, double distance)
    {
        this.nodeID = nodeID;
        this.distance = distance;
    }

    public override string ToString()
    {
        return "[ " + nodeID + " " + distance.ToString("F1") + " ]";
    }
}

public class MyPriorityQueue
{
    public List<NodeDistance> list;

    public MyPriorityQueue()
    {
        this.list = new List<NodeDistance>();
    }

    private int IndexOf(long nodeID)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].nodeID == nodeID)
            {
                return i;
            }
        }
        return -1;
    }

    private int IndexOfSmallestDist()
    {
        double smallDist = this.list[0].distance;
        int smallIndex = 0;
        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i].distance < smallDist)
            {
                smallDist = list[i].distance;
                smallIndex = i;
            }
        }
        return smallIndex;
    }

    public NodeDistance Dequeue()
    {
        int i = IndexOfSmallestDist();
        NodeDistance result = list[i];
        list.RemoveAt(i);
        return result;
    }

    public void Enqueue(NodeDistance nd)
    {
        list.Add(nd);
    }

    public void ChangePriority(long nodeID, double newDist)
    {
        int i = IndexOf(nodeID);
        list[i].distance = newDist;
    }

    public int Count()
    {
        return this.list.Count;
    }

    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < list.Count; ++i)
        {
            s += list[i] + " ";
        }
        return s;
    }
}
