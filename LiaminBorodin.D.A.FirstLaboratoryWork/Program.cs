using System.Text;

namespace LiaminBorodin.D.A.FirstLaboratoryWork
{
	public class Program
	{
		private static readonly string _infoForContext = "text/html; charset=utf-8";

		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			WebApplication app = builder.Build();

			_ = app.Map("/", FirstTaskAsync);

			_ = app.Map("/second", SecondTaskAsync);

			_ = app.Map("/third", ThirdTaskAsync);

			_ = app.Map("/fourth", FourthTaskAsync);

			_ = app.Map("/fifth", FifthTaskAsync);

			_ = app.Map("/sixth", SixthTaskAsync);

			_ = app.Map("/seventh", SeventhTaskAsync);

			_ = app.Map("/eighth", EighthTaskAsync);

			app.Run();
		}

		private static async Task FirstTaskAsync(HttpContext context)
		{
			HttpResponse response = context.Response;

			response.ContentType = _infoForContext;

			string[] linksToScripts = { "/second", "/third", "/fourth", "/fifth", "/sixth", "/seventh", "/eighth" };

			for (int i = 0; i < linksToScripts.Length; i++)
			{
				await response.WriteAsync($"<br>{linksToScripts[i]}</br>");
			}
		}

		private static async Task SecondTaskAsync(HttpContext context)
		{
			HttpResponse response = context.Response;

			response.Headers.ContentLanguage = "ru-Ru";

			response.Headers.ContentType = _infoForContext;

			await response.WriteAsync("<html><body>");

			await response.WriteAsync("<table border = 1>");

			for (int i = 0; i < 5; i++)
			{
				await response.WriteAsync("<tr>");

				for (int j = 0; j < 3; j++)
				{
					string color;

					if ((i + j) % 2 == 0)
					{
						color = "#000000";
					}
					else
					{
						color = "#ffffff";
					}

					await response.WriteAsync($"<td bgcolor={color}>{i},{j}</td>");
				}

				await response.WriteAsync("</tr>");
			}

			await response.WriteAsync("</table>");

			await response.WriteAsync("</body></html>");
		}

		private static async Task ThirdTaskAsync(HttpContext context)
		{
			HttpResponse response = context.Response;

			response.ContentType = _infoForContext;

			StringBuilder stringBuilder = new("<table>");

			foreach (KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues> header in context.Request.Headers)
			{
				_ = stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
			}

			_ = stringBuilder.Append("</table>");

			await response.WriteAsync(stringBuilder.ToString());
		}

		private static async Task FourthTaskAsync(HttpContext context)
		{
			HttpResponse response = context.Response;

			response.ContentType = _infoForContext;

			await response.WriteAsync("<h1>Hello World!!!</h1>");
		}

		private static async Task FifthTaskAsync(HttpContext context)
		{
			HttpResponse response = context.Response;

			response.ContentType = _infoForContext;

			await response.WriteAsync("<h2>Меня зовут Даня, мне 18 лет</h2>");
		}

		private static async Task SixthTaskAsync(HttpContext context)
		{
			HttpResponse response = context.Response;

			await response.WriteAsync("<table>");

			await response.WriteAsync("<thead><tr><th>Red</th><th>Green</th><th>Blue</th><th>Color</th></tr></thead>");

			await response.WriteAsync("<tbody>");

			for (int red = 0; red <= 255; red++)
			{
				for (int green = 0; green <= 255; green++)
				{
					for (int blue = 0; blue <= 255; blue++)
					{
						string color = $"#{red:X2}{green:X2}{blue:X2}";

						await response.WriteAsync("<tr>");

						await response.WriteAsync($"<td>{red}</td>");

						await response.WriteAsync($"<td>{green}</td>");

						await response.WriteAsync($"<td>{blue}</td>");

						await response.WriteAsync($"<td style='background-color:{color};'>{color}</td>");

						await response.WriteAsync("</tr>");
					}
				}
			}

			await response.WriteAsync("</tbody>");

			await response.WriteAsync("</table>");
		}

		private static async Task SeventhTaskAsync(HttpContext context)
		{
			HttpResponse response = context.Response;

			response.ContentType = _infoForContext;

			await response.WriteAsync("<html><body>");

			await response.WriteAsync("<table border = 1>");

			for (int i = 0; i < 10; i++)
			{
				await response.WriteAsync("<tr>");

				for (int j = 0; j < 10; j++)
				{
					await response.WriteAsync($"<td>{i * j}</td>");
				}

				await response.WriteAsync("</tr>");
			}

			await response.WriteAsync("</table>");

			await response.WriteAsync("</body></html>");
		}

		private static async Task EighthTaskAsync(HttpContext context)
		{
			HttpResponse response = context.Response;

			response.ContentType = _infoForContext;

			int[] numbers = Enumerable.Range(10, 14).ToArray();

			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < numbers.Length; j++)
				{
					int n = numbers[j];

					if (n == 16)
					{
						continue;
					}
					else
					{
						await response.WriteAsync($"{n}\t");

						if (n >= 12 && n <= 15)
						{
							await response.WriteAsync($"{n}\t");
						}
					}
				}

				await response.WriteAsync("<br></br>");
			}
		}
	}
}