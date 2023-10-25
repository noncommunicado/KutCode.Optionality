using KutCode.Optionality.Api.SystemTextJson.ShowCase;
using KutCode.Optionality.Api.SystemTextJson.ShowCase.Models;
using KutCode.Optionality;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapPost("/as_is", async (RequestResponseModel request) => {
	return Results.Ok(request);
});
app.MapPost("/modify", async (RequestResponseModel request) => {
	request.Id *= 2;
	if (request.Item.HasValue) {
		request.Item.Value.Id *= 2;
		request.Item.Value.SomeString += "Additional info";
	}
	request.OptInt = request.OptInt.Fallback(12);
	request.OptString = request.OptString.Fallback("some changed string");
	return Results.Ok(request);
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();