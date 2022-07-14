# ApiConventions.CommunityToolKit�������߰�
ApiConventions.CommunityToolKit API�������߰� 
1. �������淶��дAPI;
2. ��API��������������
3. ͳһ���ؽ����װ��
4. ����У�飻
5. �Զ����쳣��׽��

## ���а汾˵��

|�汾|����|
|--|--|
|1.0.0|����Լ��|
|1.0.1|���ӽ��������������У����������쳣��׽������|
|1.0.2|����Swagger�ĵ�ע�͹�����|
## Definition
Namespace:  ApiConventions.CommunityToolKit
Assembly:  ApiConventions.CommunityToolKit.dll

## Examples

- ����

```
using ApiConventions.CommunityToolKit.Extends;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGenCommunityToolKitFilter(builder);

builder.Services.AddResponseResultCommunityToolKitFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
        $"{builder.Environment.ApplicationName} v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


```

   