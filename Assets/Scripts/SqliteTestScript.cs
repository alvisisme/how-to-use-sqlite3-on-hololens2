using UnityEngine;

using SQLite;
using TMPro;

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
        db.CreateTable<Stock>();

        // insert
        Stock sampleData = new Stock();
        sampleData.Symbol = "A sample data";
        db.Insert(sampleData);

        // query
        var query = db.Table<Stock>().Where(v => v.Symbol.StartsWith("A"));
        foreach(var stock in query)
        {
            tmp.text += stock.Id + ":" + stock.Symbol + '\n';
        }

        db.Close();
    }
}
