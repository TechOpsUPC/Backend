﻿using Microsoft.AspNetCore.Mvc.ApplicationModels;
using zenflicks_backend.shared.infrastructure.interfaces.ASP.configuration.extensions;

namespace zenflicks_backend.shared.infrastructure.interfaces.ASP.configuration;

public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel != null ? new AttributeRouteModel
        {
            Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase())
        } : null;
    }
    
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }

        foreach (var selector in controller.Actions.SelectMany(a => a.Selectors))
        {
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }
        
            
        
    }
    
}