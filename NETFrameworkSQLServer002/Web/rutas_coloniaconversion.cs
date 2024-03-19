using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class rutas_coloniaconversion : GXProcedure
   {
      public rutas_coloniaconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("EstadoCuenta", false);
      }

      public rutas_coloniaconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor RUTAS_COLO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A5RutaColoniaId = RUTAS_COLO2_A5RutaColoniaId[0];
            n5RutaColoniaId = RUTAS_COLO2_n5RutaColoniaId[0];
            A4COLONIA = RUTAS_COLO2_A4COLONIA[0];
            n4COLONIA = RUTAS_COLO2_n4COLONIA[0];
            A3RUTAS_COLONIARUTA = RUTAS_COLO2_A3RUTAS_COLONIARUTA[0];
            /*
               INSERT RECORD ON TABLE GXA0006

            */
            AV2RUTAS_COLONIARUTA = A3RUTAS_COLONIARUTA;
            if ( RUTAS_COLO2_n4COLONIA[0] )
            {
               AV3COLONIA = " ";
            }
            else
            {
               AV3COLONIA = A4COLONIA;
            }
            if ( RUTAS_COLO2_n5RutaColoniaId[0] )
            {
               AV4RutaColoniaId = 0;
            }
            else
            {
               AV4RutaColoniaId = A5RutaColoniaId;
            }
            /* Using cursor RUTAS_COLO3 */
            pr_default.execute(1, new Object[] {AV2RUTAS_COLONIARUTA, AV3COLONIA, AV4RutaColoniaId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0006");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         RUTAS_COLO2_A5RutaColoniaId = new int[1] ;
         RUTAS_COLO2_n5RutaColoniaId = new bool[] {false} ;
         RUTAS_COLO2_A4COLONIA = new string[] {""} ;
         RUTAS_COLO2_n4COLONIA = new bool[] {false} ;
         RUTAS_COLO2_A3RUTAS_COLONIARUTA = new decimal[1] ;
         A4COLONIA = "";
         AV3COLONIA = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rutas_coloniaconversion__default(),
            new Object[][] {
                new Object[] {
               RUTAS_COLO2_A5RutaColoniaId, RUTAS_COLO2_n5RutaColoniaId, RUTAS_COLO2_A4COLONIA, RUTAS_COLO2_n4COLONIA, RUTAS_COLO2_A3RUTAS_COLONIARUTA
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A5RutaColoniaId ;
      private int GIGXA0006 ;
      private int AV4RutaColoniaId ;
      private decimal A3RUTAS_COLONIARUTA ;
      private decimal AV2RUTAS_COLONIARUTA ;
      private string Gx_emsg ;
      private bool n5RutaColoniaId ;
      private bool n4COLONIA ;
      private string A4COLONIA ;
      private string AV3COLONIA ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] RUTAS_COLO2_A5RutaColoniaId ;
      private bool[] RUTAS_COLO2_n5RutaColoniaId ;
      private string[] RUTAS_COLO2_A4COLONIA ;
      private bool[] RUTAS_COLO2_n4COLONIA ;
      private decimal[] RUTAS_COLO2_A3RUTAS_COLONIARUTA ;
   }

   public class rutas_coloniaconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmRUTAS_COLO2;
          prmRUTAS_COLO2 = new Object[] {
          };
          Object[] prmRUTAS_COLO3;
          prmRUTAS_COLO3 = new Object[] {
          new ParDef("@AV2RUTAS_COLONIARUTA",GXType.Decimal,18,6) ,
          new ParDef("@AV3COLONIA",GXType.VarChar,255,0) ,
          new ParDef("@AV4RutaColoniaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("RUTAS_COLO2", "SELECT [RutaColoniaId], [COLONIA], [RUTA] FROM dbo.[RUTAS_COLONIA] ORDER BY [RUTA] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmRUTAS_COLO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("RUTAS_COLO3", "INSERT INTO [GXA0006]([RUTAS_COLONIARUTA], [COLONIA], [RutaColoniaId]) VALUES(@AV2RUTAS_COLONIARUTA, @AV3COLONIA, @AV4RutaColoniaId)", GxErrorMask.GX_NOMASK,prmRUTAS_COLO3)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                return;
       }
    }

 }

}
