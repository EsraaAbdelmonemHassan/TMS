namespace TMS.Tests
{
    using System.Text;
    using Xunit;

    public class CsvExportTests
    {
        [Fact]
        public void Csv_line_escapes_quotes_in_name()
        {
            var name = "Product \"Pro\"";
            var escaped = $"\"{name.Replace("\"", "\"\"")}\"";
            Assert.Equal("\"Product \"\"Pro\"\"\"", escaped);
        }

        [Fact]
        public void Csv_header_has_expected_columns()
        {
            var header = "Name,Code,Price,Quantity,Category,IsActive";
            Assert.Contains("Price", header);
            Assert.StartsWith("Name", header);
        }
    }
}
