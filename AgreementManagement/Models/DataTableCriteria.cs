namespace AgreementManagement.Models
{
	public class DataTableCriteria<T>
	{
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public string SearchingValue { get; set; }
        public string SortingDirection { get; set; } // TODO: create enum
        public int RecordsTotalCount { get; set; }
        public List<T> Data { get; set; }
    }
}
