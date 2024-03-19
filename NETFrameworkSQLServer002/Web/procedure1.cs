using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class procedure1 : GXProcedure
   {
      public procedure1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public procedure1( IGxContext context )
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
         /* Using cursor P000G2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A3RUTAS_COLONIARUTA = P000G2_A3RUTAS_COLONIARUTA[0];
            AV8count = (short)(AV8count+1);
            /* Using cursor P000G3 */
            pr_default.execute(1, new Object[] {A3RUTAS_COLONIARUTA});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A6CLAVES_RUTASRUTA = P000G3_A6CLAVES_RUTASRUTA[0];
               n6CLAVES_RUTASRUTA = P000G3_n6CLAVES_RUTASRUTA[0];
               A1CLAVE_CATASTRAL = P000G3_A1CLAVE_CATASTRAL[0];
               AV9clave = A1CLAVE_CATASTRAL;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV8count > 0 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
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
         P000G2_A3RUTAS_COLONIARUTA = new decimal[1] ;
         P000G3_A6CLAVES_RUTASRUTA = new decimal[1] ;
         P000G3_n6CLAVES_RUTASRUTA = new bool[] {false} ;
         P000G3_A1CLAVE_CATASTRAL = new string[] {""} ;
         A1CLAVE_CATASTRAL = "";
         AV9clave = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.procedure1__default(),
            new Object[][] {
                new Object[] {
               P000G2_A3RUTAS_COLONIARUTA
               }
               , new Object[] {
               P000G3_A6CLAVES_RUTASRUTA, P000G3_n6CLAVES_RUTASRUTA, P000G3_A1CLAVE_CATASTRAL
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8count ;
      private decimal A3RUTAS_COLONIARUTA ;
      private decimal A6CLAVES_RUTASRUTA ;
      private bool n6CLAVES_RUTASRUTA ;
      private string A1CLAVE_CATASTRAL ;
      private string AV9clave ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] P000G2_A3RUTAS_COLONIARUTA ;
      private decimal[] P000G3_A6CLAVES_RUTASRUTA ;
      private bool[] P000G3_n6CLAVES_RUTASRUTA ;
      private string[] P000G3_A1CLAVE_CATASTRAL ;
   }

   public class procedure1__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          };
          Object[] prmP000G3;
          prmP000G3 = new Object[] {
          new ParDef("@RUTAS_COLONIARUTA",GXType.Decimal,18,6)
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT [RUTA] AS RUTAS_COLONIARUTA FROM dbo.[RUTAS_COLONIA] ORDER BY [RUTA] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000G3", "SELECT [RUTA] AS CLAVES_RUTASRUTA, [CLAVE_CATASTRAL] FROM dbo.[CLAVES_RUTAS] WHERE [RUTA] = @RUTAS_COLONIARUTA ORDER BY [CLAVE_CATASTRAL] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G3,100, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 1 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
