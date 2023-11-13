﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.WebApi.Controllers.Areas;

[ApiController]
public class BaseApiController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
