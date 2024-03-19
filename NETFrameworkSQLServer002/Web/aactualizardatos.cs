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
   public class aactualizardatos : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("EstadoCuenta", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aactualizardatos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("EstadoCuenta", true);
      }

      public aactualizardatos( IGxContext context )
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
         /* Using cursor P000D2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A8ClavesRutaId = P000D2_A8ClavesRutaId[0];
            n8ClavesRutaId = P000D2_n8ClavesRutaId[0];
            A1CLAVE_CATASTRAL = P000D2_A1CLAVE_CATASTRAL[0];
            AV8Count = (short)(AV8Count+1);
            A8ClavesRutaId = AV8Count;
            n8ClavesRutaId = false;
            /* Using cursor P000D3 */
            pr_default.execute(1, new Object[] {n8ClavesRutaId, A8ClavesRutaId, A1CLAVE_CATASTRAL});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("CLAVES_RUTAS");
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("actualizardatos",pr_default);
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         P000D2_A8ClavesRutaId = new int[1] ;
         P000D2_n8ClavesRutaId = new bool[] {false} ;
         P000D2_A1CLAVE_CATASTRAL = new string[] {""} ;
         A1CLAVE_CATASTRAL = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aactualizardatos__default(),
            new Object[][] {
                new Object[] {
               P000D2_A8ClavesRutaId, P000D2_n8ClavesRutaId, P000D2_A1CLAVE_CATASTRAL
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV8Count ;
      private int A8ClavesRutaId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private bool n8ClavesRutaId ;
      private string A1CLAVE_CATASTRAL ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000D2_A8ClavesRutaId ;
      private bool[] P000D2_n8ClavesRutaId ;
      private string[] P000D2_A1CLAVE_CATASTRAL ;
   }

   public class aactualizardatos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000D2;
          prmP000D2 = new Object[] {
          };
          Object[] prmP000D3;
          prmP000D3 = new Object[] {
          new ParDef("@ClavesRutaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@CLAVE_CATASTRAL",GXType.NVarChar,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000D2", "SELECT [ClavesRutaId], [CLAVE_CATASTRAL] FROM dbo.[CLAVES_RUTAS] WITH (UPDLOCK) ORDER BY [CLAVE_CATASTRAL] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000D3", "UPDATE dbo.[CLAVES_RUTAS] SET [ClavesRutaId]=@ClavesRutaId  WHERE [CLAVE_CATASTRAL] = @CLAVE_CATASTRAL", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000D3)
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
                return;
       }
    }

 }

}
