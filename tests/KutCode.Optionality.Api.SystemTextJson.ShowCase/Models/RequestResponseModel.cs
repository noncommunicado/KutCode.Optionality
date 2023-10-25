
using KutCode.Optionality;

namespace KutCode.Optionality.Api.SystemTextJson.ShowCase.Models;

public class RequestResponseModel
{
	public int Id { get; set; } = 10;
	public Optional<ItemModel> Item { get; set; }
	public Optional<string> OptString { get; set; }
	public OptionalValue<int> OptInt { get; set; }
}