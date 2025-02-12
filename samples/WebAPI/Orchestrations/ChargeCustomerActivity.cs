﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.DurableTask;
using WebAPI.Models;

namespace WebAPI.Orchestrations;

[DurableTask("ChargeCustomer")]
public class ChargeCustomerActivity : TaskActivityBase<OrderInfo, object>
{
    readonly ILogger logger;

    // Dependencies are injected from ASP.NET host service container
    public ChargeCustomerActivity(ILogger<ChargeCustomerActivity> logger)
    {
        this.logger = logger;
    }

    protected override async Task<object?> OnRunAsync(TaskActivityContext context, OrderInfo? orderInfo)
    {
        this.logger.LogInformation(
            "{instanceId}: Charging customer {price:C}'...",
            context.InstanceId,
            orderInfo?.Price ?? 0.0);

        await Task.Delay(TimeSpan.FromSeconds(3));
        return null;
    }
}
