using System.Collections;

Hashtable ht = new Hashtable()
            {
                { 101, "Alice" },
                { 102, "Bob" },
                { 103, "Charlie" },
                { 104, "Diana" }
           };


if (!ht.ContainsKey(105))
{
    ht.Add(105, "Edward");
}
else
{
    Console.WriteLine("ID already exists");
}

string employeeName = (string)ht[102];

Console.WriteLine(employeeName);

foreach (DictionaryEntry v in ht)
{
    Console.WriteLine($"{v.Key} : {v.Value}" );
}


ht.Remove(103);

foreach (DictionaryEntry v in ht)
{
    Console.WriteLine($"{v.Key} : {v.Value}");
}

