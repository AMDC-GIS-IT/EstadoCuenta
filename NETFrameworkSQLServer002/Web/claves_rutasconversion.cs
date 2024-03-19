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
   public class claves_rutasconversion : GXProcedure
   {
      public claves_rutasconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("EstadoCuenta", false);
      }

      public claves_rutasconversion( IGxContext context )
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
         /* Using cursor CLAVES_RUT2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1CLAVE_CATASTRAL = CLAVES_RUT2_A1CLAVE_CATASTRAL[0];
            A8ClavesRutaId = CLAVES_RUT2_A8ClavesRutaId[0];
            n8ClavesRutaId = CLAVES_RUT2_n8ClavesRutaId[0];
            A7UMAPS = CLAVES_RUT2_A7UMAPS[0];
            n7UMAPS = CLAVES_RUT2_n7UMAPS[0];
            A6CLAVES_RUTASRUTA = CLAVES_RUT2_A6CLAVES_RUTASRUTA[0];
            n6CLAVES_RUTASRUTA = CLAVES_RUT2_n6CLAVES_RUTASRUTA[0];
            /*
               INSERT RECORD ON TABLE GXA0004

            */
            AV2CLAVES_RUTASRUTA = A6CLAVES_RUTASRUTA;
            if ( CLAVES_RUT2_n7UMAPS[0] )
            {
               AV3UMAPS = 0;
               nV3UMAPS = false;
               nV3UMAPS = true;
            }
            else
            {
               AV3UMAPS = A7UMAPS;
               nV3UMAPS = false;
            }
            if ( CLAVES_RUT2_n8ClavesRutaId[0] )
            {
               AV4ClavesRutaId = 0;
               nV4ClavesRutaId = false;
               nV4ClavesRutaId = true;
            }
            else
            {
               AV4ClavesRutaId = A8ClavesRutaId;
               nV4ClavesRutaId = false;
            }
            AV5CLAVE_CATASTRAL = A1CLAVE_CATASTRAL;
            nV5CLAVE_CATASTRAL = false;
            /* Using cursor CLAVES_RUT3 */
            pr_default.execute(1, new Object[] {AV2CLAVES_RUTASRUTA, nV3UMAPS, AV3UMAPS, nV4ClavesRutaId, AV4ClavesRutaId, nV5CLAVE_CATASTRAL, AV5CLAVE_CATASTRAL});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0004");
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
         CLAVES_RUT2_A1CLAVE_CATASTRAL = new string[] {""} ;
         CLAVES_RUT2_A8ClavesRutaId = new int[1] ;
         CLAVES_RUT2_n8ClavesRutaId = new bool[] {false} ;
         CLAVES_RUT2_A7UMAPS = new decimal[1] ;
         CLAVES_RUT2_n7UMAPS = new bool[] {false} ;
         CLAVES_RUT2_A6CLAVES_RUTASRUTA = new decimal[1] ;
         CLAVES_RUT2_n6CLAVES_RUTASRUTA = new bool[] {false} ;
         A1CLAVE_CATASTRAL = "";
         AV5CLAVE_CATASTRAL = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.claves_rutasconversion__default(),
            new Object[][] {
                new Object[] {
               CLAVES_RUT2_A1CLAVE_CATASTRAL, CLAVES_RUT2_A8ClavesRutaId, CLAVES_RUT2_n8ClavesRutaId, CLAVES_RUT2_A7UMAPS, CLAVES_RUT2_n7UMAPS, CLAVES_RUT2_A6CLAVES_RUTASRUTA, CLAVES_RUT2_n6CLAVES_RUTASRUTA
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A8ClavesRutaId ;
      private int GIGXA0004 ;
      private int AV4ClavesRutaId ;
      private decimal A7UMAPS ;
      private decimal A6CLAVES_RUTASRUTA ;
      private decimal AV2CLAVES_RUTASRUTA ;
      private decimal AV3UMAPS ;
      private string Gx_emsg ;
      private bool n8ClavesRutaId ;
      private bool n7UMAPS ;
      private bool n6CLAVES_RUTASRUTA ;
      private bool nV3UMAPS ;
      private bool nV4ClavesRutaId ;
      private bool nV5CLAVE_CATASTRAL ;
      private string A1CLAVE_CATASTRAL ;
      private string AV5CLAVE_CATASTRAL ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] CLAVES_RUT2_A1CLAVE_CATASTRAL ;
      private int[] CLAVES_RUT2_A8ClavesRutaId ;
      private bool[] CLAVES_RUT2_n8ClavesRutaId ;
      private decimal[] CLAVES_RUT2_A7UMAPS ;
      private bool[] CLAVES_RUT2_n7UMAPS ;
      private decimal[] CLAVES_RUT2_A6CLAVES_RUTASRUTA ;
      private bool[] CLAVES_RUT2_n6CLAVES_RUTASRUTA ;
   }

   public class claves_rutasconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmCLAVES_RUT2;
          prmCLAVES_RUT2 = new Object[] {
          };
          Object[] prmCLAVES_RUT3;
          prmCLAVES_RUT3 = new Object[] {
          new ParDef("@AV2CLAVES_RUTASRUTA",GXType.Decimal,18,6) ,
          new ParDef("@AV3UMAPS",GXType.Decimal,18,6){Nullable=true} ,
          new ParDef("@AV4ClavesRutaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV5CLAVE_CATASTRAL",GXType.VarChar,255,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("CLAVES_RUT2", "SELECT [CLAVE_CATASTRAL], [ClavesRutaId], [UMAPS], [RUTA] FROM dbo.[CLAVES_RUTAS] WHERE Not [RUTA] IS NULL ORDER BY [CLAVE_CATASTRAL] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLAVES_RUT2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CLAVES_RUT3", "INSERT INTO [GXA0004]([CLAVES_RUTASRUTA], [UMAPS], [ClavesRutaId], [CLAVE_CATASTRAL]) VALUES(@AV2CLAVES_RUTASRUTA, @AV3UMAPS, @AV4ClavesRutaId, @AV5CLAVE_CATASTRAL)", GxErrorMask.GX_NOMASK,prmCLAVES_RUT3)
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
