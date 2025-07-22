using System;
namespace MywebApiApp.Models
{
	public class TaskItem
	{
		public int Id { get; set; } // Unique Task ID
		public string Title { get; set; } = string.Empty; // Task title
		public bool IsCompleted { get; set; } = false; // Task status
	}
}

