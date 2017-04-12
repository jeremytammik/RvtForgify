#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace RvtForgify
{

  //<AddIn Type = "Application" >
  //  < Name > Application RvtForgify</Name>
  //  <Assembly>RvtForgify.dll</Assembly>
  //  <FullClassName>RvtForgify.App</FullClassName>
  //  <ClientId>9e665e24-9a1a-48a7-aefe-4e32a1c88e5d</ClientId>
  //  <VendorId>com.typepad.thebuildingcoder</VendorId>
  //  <VendorDescription>The Building Coder, http://thebuildingcoder.typepad.com</VendorDescription>
  //</AddIn>

  class App : IExternalApplication
  {
    public Result OnStartup( UIControlledApplication a )
    {
      return Result.Succeeded;
    }

    public Result OnShutdown( UIControlledApplication a )
    {
      return Result.Succeeded;
    }
  }
}
