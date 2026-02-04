# RX-Explorer-WAS-PluginDefinition

[![License](https://img.shields.io/github/license/zhuxb711/RX-Explorer-WAS-PluginDefinition)](https://github.com/zhuxb711/RX-Explorer-WAS-PluginDefinition/blob/main/LICENSE)
[![NuGet Version](https://img.shields.io/nuget/v/RX-Explorer-WAS.PluginDefinition)](https://www.nuget.org/packages/RX-Explorer-WAS.PluginDefinition)
[![NuGet Downloads](https://img.shields.io/nuget/dt/RX-Explorer-WAS.PluginDefinition)](https://www.nuget.org/packages/RX-Explorer-WAS.PluginDefinition)

## 简介

RX-Explorer-WAS-PluginDefinition 是为 [RX-Explorer-WAS](https://github.com/zhuxb711/RX-Explorer-WAS) 提供的官方插件开发框架。通过此框架，开发者可以为 RX-Explorer-WAS 功能丰富的插件，扩展其核心功能。

## 安装

### 通过 NuGet 安装

#### 通过 .NET CLI 安装

```bash
dotnet add package RX-Explorer-WAS.PluginDefinition
```

#### 通过 Package Manager Console 安装

```powershell
Install-Package RX-Explorer-WAS.PluginDefinition
```

#### 通过 PackageReference 安装

在项目文件 (.csproj) 中添加：

```xml
<PackageReference Include="RX-Explorer-WAS.PluginDefinition" Version="1.6.1" />
```

## 快速开始

### 1. 创建基础插件

```csharp
using RX_Explorer_WAS.PluginDefinition;
using RX_Explorer_WAS.PluginDefinition.Enum;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class MyPlugin : IInvokablePluginComponent
{
    public Guid UniqueId => new Guid("your-unique-guid-here");

    public string AppMinVersion => "1.0.0.0";

    public IEnumerable<IPluginFeatureComponent> AvailableFeatures { get; } = new[]
    {
        new MyFeature()
    };

    public string GetLocaleName(string locale)
    {
        return locale switch
        {
            "zh-CN" => "我的插件",
            _ => "My Plugin"
        };
    }

    public string GetLocaleDescription(string locale)
    {
        return locale switch
        {
            "zh-CN" => "这是一个示例插件",
            _ => "This is a sample plugin"
        };
    }

    public async Task<object> InvokeFeatureAsync(Guid featureGuid,
        IEnumerable<string> arguments = null,
        CancellationToken cancelToken = default)
    {
        // 实现你的插件逻辑
        await Task.Delay(100, cancelToken);
        return null;
    }

    public void Dispose()
    {
        // 清理资源
    }
}
```

### 2. 创建功能组件

```csharp
using RX_Explorer_WAS.PluginDefinition;
using RX_Explorer_WAS.PluginDefinition.Enum;
using System;

public class MyFeature : IPluginFeatureComponent
{
    public Guid UniqueId => new Guid("feature-unique-guid-here");

    public WorkScenario Scenario => WorkScenario.Launch;

    public bool IsEnabled => true;

    public bool IsElevationRequired => false;

    public string GetLocaleName(string locale)
    {
        return locale switch
        {
            "zh-CN" => "我的功能",
            _ => "My Feature"
        };
    }

    public string GetLocaleDescription(string locale)
    {
        return locale switch
        {
            "zh-CN" => "这是一个示例功能",
            _ => "This is a sample feature"
        };
    }

    public string GetLocaleUnavailableReason(string locale)
    {
        return locale switch
        {
            "zh-CN" => "功能暂不可用",
            _ => "Feature is not available"
        };
    }
}
```

## 接口说明

### 核心接口

#### `IPluginComponent`

所有插件组件的基础接口，定义了插件的基本属性和生命周期管理。

#### `IInvokablePluginComponent`

可调用插件接口，继承自 `IPluginComponent`，用于实现可被 RX-Explorer-WAS 调用的插件功能。

#### `IPluginFeatureComponent`

插件功能组件接口，定义单个功能的属性和行为。

#### `IStatusMotivationPluginComponent`

状态驱动插件接口，用于处理功能状态变化事件。

### 工作场景 (WorkScenario)

| 场景        | 说明                   | 用途                     |
| ----------- | ---------------------- | ------------------------ |
| `None`      | 不在任何场景下自动调用 | 手动触发的功能           |
| `Launch`    | 应用启动时自动调用     | 初始化操作               |
| `Shutdown`  | 应用关闭时自动调用     | 清理操作                 |
| `Elevation` | 需要提升权限时自动调用 | 为进程提供权限提升的方法 |

### 功能状态 (FeatureStatus)

| 状态       | 说明             |
| ---------- | ---------------- |
| `Active`   | 功能已被用户启用 |
| `Deactive` | 功能已被用户禁用 |

## 最佳实践

### 1. 唯一标识符

```csharp
// 为每个插件和功能生成唯一的 GUID
public Guid UniqueId => new Guid("12345678-1234-5678-9ABC-123456789ABC");
```

### 2. 本地化支持

```csharp
public string GetLocaleName(string locale)
{
    return locale switch
    {
        "zh-Hans" => "中文名称",
        "en-US" => "English Name",
        _ => "Default Name"
    };
}
```

### 3. 异步操作

```csharp
public async Task<object> InvokeFeatureAsync(Guid featureGuid,
    IEnumerable<string> arguments = null,
    CancellationToken cancelToken = default)
{
    try
    {
        // 检查取消令牌
        cancelToken.ThrowIfCancellationRequested();

        // 执行异步操作
        var result = await SomeAsyncOperation(cancelToken);

        return result;
    }
    catch (OperationCanceledException)
    {
        // 处理取消操作
        throw;
    }
}
```

### 4. 资源管理

```csharp
public void Dispose()
{
    // 释放托管资源
    managedResource?.Dispose();

    // 释放非托管资源
    if (unmanagedResource != IntPtr.Zero)
    {
        // 释放非托管资源
        unmanagedResource = IntPtr.Zero;
    }

    GC.SuppressFinalize(this);
}
```

### 开发环境要求

- Git
- .NET 10.0 SDK
- Visual Studio 2026 或更高版本

## 许可证

本项目采用 [Apache License 2.0 许可证](LICENSE)。

---

如果您在使用过程中遇到任何问题，请随时 [提交 Issue](https://github.com/zhuxb711/RX-Explorer-WAS-PluginDefinition/issues) 或参与 [讨论](https://github.com/zhuxb711/RX-Explorer-WAS-PluginDefinition/discussions)。
