using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct CountVowels
{
    private SqlInt32 countOfVowels;

    public void Init()
    {
        countOfVowels = 0;
    }

    public void Accumulate(SqlString Value)
    {
        string vowels = "aeiou";

        for (int i = 0; i < Value.ToString().Length; i++)
        {
            for (int j = 0; j < vowels.Length; j++)
            {
                if (Value.Value.Substring(i,1).ToLower() == vowels.Substring(j, 1))
                {
                    countOfVowels += 1;
                }
            }
        }
    }

    public void Merge(CountVowels Group)
    {
        //Accumulate(Group.Terminate());
        this.countOfVowels += Group.countOfVowels;

    }

    public SqlInt32 Terminate()
    {
        // Put your code here
        return countOfVowels;
    }

}
