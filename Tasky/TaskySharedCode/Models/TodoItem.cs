using SQLite;

namespace Tasky.Shared.Models 
{
	[Table("todoItem")]
	public class TodoItem 
	{
		[PrimaryKey, AutoIncrement]
        public int ID { get; set; }

		[MaxLength(50), Unique]
		public string Name { get; set; }

		[MaxLength(400), Unique]
		public string Notes { get; set; }

		public bool Done { get; set; }	// TODO: add this field to the user-interface
	}
}