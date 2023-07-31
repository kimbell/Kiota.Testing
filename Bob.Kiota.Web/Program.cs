using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(j => j.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.IncludeXmlComments("bin\\Debug\\net7.0\\Bob.Kiota.Web.xml", true);
    o.UseAllOfForInheritance();
    o.UseOneOfForPolymorphism();
    o.SelectDiscriminatorNameUsing(type =>
    {
        // see if the code has been annotated
        var attribute = type
            .GetCustomAttributes(true)
            .OfType<JsonPolymorphicAttribute>()
            .FirstOrDefault();

        // if nothing has been found, use default name. This is the same for both STJ and Newtonsoft
        return attribute?.TypeDiscriminatorPropertyName ?? "$type";
    });
    o.SelectDiscriminatorValueUsing(type =>
    {
        // figures out the value of the discriminator
        if (type.BaseType == null)
        {
            return null;
        }

        var attribute = type
            .BaseType
            .GetCustomAttributes(true)
            .OfType<JsonDerivedTypeAttribute>()
            .FirstOrDefault(x => x.DerivedType == type);

        return attribute?.TypeDiscriminator?.ToString();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{

}