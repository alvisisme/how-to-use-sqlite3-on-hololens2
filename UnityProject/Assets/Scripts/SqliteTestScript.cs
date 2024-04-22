using UnityEngine;
using TMPro;
using SQLite;

public class SqliteTestScript : MonoBehaviour
{
    private TextMeshPro tmp;

    public class Stock
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Symbol { get; set; }
    }

    // Start is called before the first frame update
    void Start()
    {
        tmp = this.gameObject.GetComponent<TextMeshPro>();

        var databasePath = Application.persistentDataPath + "/TestDatabase.db";
        var db = new SQLiteConnection(databasePath);
        var msg = "";
        Debug.Log("[sqlite] creating database at " + databasePath);
        db.CreateTable<Stock>();
        Debug.Log("[sqlite] database created at " + databasePath);
        // query
        var query = db.Table<Stock>().Where(v => v.Symbol.StartsWith("A"));
        var count = query.Count();
        Debug.Log("[sqlite] found records " + count);

        // insert
        Stock sampleData = new Stock();
        sampleData.Symbol = "A sample data";
        db.Insert(sampleData);

        Debug.Log("[sqlite] insert a new record ");

        // insert again
        query = db.Table<Stock>().Where(v => v.Symbol.StartsWith("A"));
        foreach (var stock in query)
        {
            msg += stock.Id + ":" + stock.Symbol + '\n';
        }
        db.Close();

        Debug.Log("[sqlite] "  + msg);
        if (tmp)
        {
            tmp.text = msg;
        }
    }
}
