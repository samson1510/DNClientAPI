namespace DataNova.Common {
  public class APIColumnQuery {
    public string data { get; set; }
    public string name { get; set; }
    public bool orderable { get; set; }
    public APISearchValue search { get; set; }
    public bool searchable { get; set; }
  }
  public class APISearchValue {
    public string value { get; set; }
    public bool regex { get; set; }
  }
  public class APIOrderQuery {
    public int column { get; set; }
    public string dir { get; set; }
  }
  public class APIFilter {
    public APIColumnQuery[] columns { get; set; }
    public string draw { get; set; }
    public int start { get; set; }
    public APIOrderQuery[] order { get; set; }
    public APISearchValue search { get; set; }
    public int length { get; set; }
    public DNAPIColumn[] ColumnInfo { get; set; }
  }
  public class APIFilter_formatted {
    public APIColumnQuery_formatted[] Columns { get; set; }
    public APIOrderQuery_formatted[] Order { get; set; }
    public int Index { get; set; }
    public int Size { get; set; }
    public DNAPIColumn[] ColumnInfo { get; set; }
  }

  public class DNAPIColumn {
    public string TableColumnName { get; set; }
    public string DisplayName { get; set; }
  }

  public class APIColumnQuery_formatted {
    public string Name { get; set; }
    public string Value { get; set; }
    public string Value2 { get; set; }
    public string Operator { get; set; } = "CONTAINS";
  }
  public class APIOrderQuery_formatted {
    public string Name { get; set; }
    public bool IsAscending { get; set; }
  }
}
