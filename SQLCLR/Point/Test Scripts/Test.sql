CREATE TABLE test_table (column1 Point)
go

INSERT INTO test_table (column1) VALUES ('1:2')
INSERT INTO test_table (column1) VALUES ('-2:3')
INSERT INTO test_table (column1) VALUES ('-3:-4')

select column1.Quadrant() from test_table

