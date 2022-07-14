# ApiConventions.CommunityToolKit社区工具包
ApiConventions.CommunityToolKit API社区工具包 
1. 帮助您规范编写API;
2. 简化API返回类型声明；
3. 统一返回结果封装；
4. 参数校验；
5. 自定义异常捕捉；

## 发行版本说明

|版本|内容|
|--|--|
|1.0.0|新增约定|
|1.0.1|增加结果过滤器、参数校验过滤器、异常捕捉过滤器|
|1.0.2|增加Swagger文档注释过滤器|
## Definition
Namespace:  ApiConventions.CommunityToolKit
Assembly:  ApiConventions.CommunityToolKit.dll

## Examples

- 代码

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

   