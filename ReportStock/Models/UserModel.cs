namespace ReportStock.Models
{
	public class UserModel
	{
		public Int64 id { get; set; }

		public string? username { get; set; }

		public string? password { get; set; }

		public string? name { get; set; }

		public string? department { get; set; }

		public string? status { get; set; }

		public DateTime createdate { get; set; }

		public string? successMessage { get; set; }

		public string? errorMessage { get; set; }




		public UserModel()
		{

		}

	}
}
