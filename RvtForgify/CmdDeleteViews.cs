#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Linq;
#endregion

namespace RvtForgify
{
  [Transaction( TransactionMode.Manual )]
  public class CmdDeleteViews : IExternalCommand
  {
    /// <summary>
    /// Delete all views except "{3D}".
    /// </summary>
    void DeleteViews( Document doc )
    {
      IEnumerable<View> views
        = new FilteredElementCollector( doc )
          .OfClass( typeof( View ) )
          .Cast<View>()
          .Where<View>( v => v.CanBePrinted
            && !v.IsTemplate
            && !"{3D}".Equals( v.ViewName ) );

      ICollection<ElementId> ids = views
        .Select<View, ElementId>( v => v.Id )
        .ToList<ElementId>();

      doc.Delete( ids );
    }

    public Result Execute(
      ExternalCommandData commandData,
      ref string message,
      ElementSet elements )
    {
      UIApplication uiapp = commandData.Application;
      UIDocument uidoc = uiapp.ActiveUIDocument;
      Document doc = uidoc.Document;

      using( Transaction tx = new Transaction( doc ) )
      {
        tx.Start( "Delete Views" );
        DeleteViews( doc );
        tx.Commit();
      }
      return Result.Succeeded;
    }
  }
}
