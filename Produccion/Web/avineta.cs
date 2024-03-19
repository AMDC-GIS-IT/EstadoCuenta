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
using GeneXus.Printer;
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
   public class avineta : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Clave");
            if ( ! entryPointCalled )
            {
               AV13Clave = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public avineta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public avineta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_Clave )
      {
         this.AV13Clave = aP0_Clave;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_Clave )
      {
         this.AV13Clave = aP0_Clave;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName(AV60Ruta);
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 12269, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV23Fecha3 = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
            AV53Hora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            /* Using cursor P000F2 */
            pr_default.execute(0, new Object[] {AV13Clave});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A7UMAPS = P000F2_A7UMAPS[0];
               n7UMAPS = P000F2_n7UMAPS[0];
               A6CLAVES_RUTASRUTA = P000F2_A6CLAVES_RUTASRUTA[0];
               n6CLAVES_RUTASRUTA = P000F2_n6CLAVES_RUTASRUTA[0];
               A1CLAVE_CATASTRAL = P000F2_A1CLAVE_CATASTRAL[0];
               AV15count = (short)(AV15count+1);
               AV51ART_ID_DOC = A1CLAVE_CATASTRAL;
               /* Using cursor P000F3 */
               pr_default.execute(1, new Object[] {n6CLAVES_RUTASRUTA, A6CLAVES_RUTASRUTA});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A3RUTAS_COLONIARUTA = P000F3_A3RUTAS_COLONIARUTA[0];
                  A4COLONIA = P000F3_A4COLONIA[0];
                  AV58COLONIA = A4COLONIA;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
               AV56UMAPS = (long)(Math.Round(A7UMAPS, 18, MidpointRounding.ToEven));
               /* Using cursor P000F4 */
               pr_default.execute(2, new Object[] {AV51ART_ID_DOC});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A2ART_ID_DOC = P000F4_A2ART_ID_DOC[0];
                  A10NOMBRE = P000F4_A10NOMBRE[0];
                  A9ACT_ID_CARD = P000F4_A9ACT_ID_CARD[0];
                  A12NOMBRE_COLONIA = P000F4_A12NOMBRE_COLONIA[0];
                  n12NOMBRE_COLONIA = P000F4_n12NOMBRE_COLONIA[0];
                  AV52count3 = (short)(AV52count3+1);
                  AV56UMAPS = (long)(Math.Round(A7UMAPS, 18, MidpointRounding.ToEven));
                  AV35Nombre = A10NOMBRE;
                  AV10ACT_ID_CARD = A9ACT_ID_CARD;
                  AV51ART_ID_DOC = A2ART_ID_DOC;
                  AV59NOMBRE_COLONIA = A12NOMBRE_COLONIA;
                  if ( AV52count3 == 1 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
               H0F0( false, 251) ;
               getPrinter().GxAttris("Arial", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nombre:", 58, Gx_line+133, 125, Gx_line+155, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Alcaldía Municipal del Distrito Cental", 108, Gx_line+17, 683, Gx_line+67, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35Nombre, "")), 125, Gx_line+133, 458, Gx_line+155, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10ACT_ID_CARD, "")), 133, Gx_line+167, 391, Gx_line+189, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51ART_ID_DOC, "")), 625, Gx_line+167, 817, Gx_line+189, 0, 0, 0, 1) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "95130b7a-b128-4e54-8298-646ac84013e4", "", context.GetTheme( )), 683, Gx_line+0, 816, Gx_line+67) ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "eda46848-09cd-492f-abad-525fdafedf51", "", context.GetTheme( )), 17, Gx_line+0, 109, Gx_line+83) ;
               getPrinter().GxAttris("Arial", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tegucigalpa, Honduras", 108, Gx_line+50, 683, Gx_line+100, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 11, true, false, false, false, 0, 128, 128, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("GERENCIA DE RECAUDACIÓN Y CONTROL FINANCIERO", 108, Gx_line+80, 683, Gx_line+130, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha:", 508, Gx_line+133, 558, Gx_line+155, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV23Fecha3, "99/99/9999"), 558, Gx_line+133, 658, Gx_line+155, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Identidad:", 58, Gx_line+167, 133, Gx_line+189, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Clave Catastral:", 508, Gx_line+167, 616, Gx_line+189, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Codigo de UMAPS:", 58, Gx_line+200, 191, Gx_line+222, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV56UMAPS), "ZZZZZZZZZZZZZZZZZ9")), 192, Gx_line+200, 417, Gx_line+222, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Colonia: ", 508, Gx_line+200, 575, Gx_line+222, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Arial", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58COLONIA, "")), 575, Gx_line+200, 800, Gx_line+222, 0, 0, 0, 1) ;
               getPrinter().GxDrawLine(0, Gx_line+250, 825, Gx_line+250, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+251);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0F0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0F0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Arial", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Arial", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if (IsMain)	waitPrinterEnd();
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
         AV60Ruta = "";
         AV23Fecha3 = DateTime.MinValue;
         AV53Hora = (DateTime)(DateTime.MinValue);
         P000F2_A7UMAPS = new decimal[1] ;
         P000F2_n7UMAPS = new bool[] {false} ;
         P000F2_A6CLAVES_RUTASRUTA = new decimal[1] ;
         P000F2_n6CLAVES_RUTASRUTA = new bool[] {false} ;
         P000F2_A1CLAVE_CATASTRAL = new string[] {""} ;
         A1CLAVE_CATASTRAL = "";
         AV51ART_ID_DOC = "";
         P000F3_A3RUTAS_COLONIARUTA = new decimal[1] ;
         P000F3_A4COLONIA = new string[] {""} ;
         A4COLONIA = "";
         AV58COLONIA = "";
         P000F4_A2ART_ID_DOC = new string[] {""} ;
         P000F4_A10NOMBRE = new string[] {""} ;
         P000F4_A9ACT_ID_CARD = new string[] {""} ;
         P000F4_A12NOMBRE_COLONIA = new string[] {""} ;
         P000F4_n12NOMBRE_COLONIA = new bool[] {false} ;
         A2ART_ID_DOC = "";
         A10NOMBRE = "";
         A9ACT_ID_CARD = "";
         A12NOMBRE_COLONIA = "";
         AV35Nombre = "";
         AV10ACT_ID_CARD = "";
         AV59NOMBRE_COLONIA = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.avineta__default(),
            new Object[][] {
                new Object[] {
               P000F2_A7UMAPS, P000F2_n7UMAPS, P000F2_A6CLAVES_RUTASRUTA, P000F2_n6CLAVES_RUTASRUTA, P000F2_A1CLAVE_CATASTRAL
               }
               , new Object[] {
               P000F3_A3RUTAS_COLONIARUTA, P000F3_A4COLONIA
               }
               , new Object[] {
               P000F4_A2ART_ID_DOC, P000F4_A10NOMBRE, P000F4_A9ACT_ID_CARD, P000F4_A12NOMBRE_COLONIA, P000F4_n12NOMBRE_COLONIA
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV15count ;
      private short AV52count3 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private long AV13Clave ;
      private long AV56UMAPS ;
      private decimal A7UMAPS ;
      private decimal A6CLAVES_RUTASRUTA ;
      private decimal A3RUTAS_COLONIARUTA ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private DateTime AV53Hora ;
      private DateTime AV23Fecha3 ;
      private bool entryPointCalled ;
      private bool n7UMAPS ;
      private bool n6CLAVES_RUTASRUTA ;
      private bool n12NOMBRE_COLONIA ;
      private string AV60Ruta ;
      private string A1CLAVE_CATASTRAL ;
      private string AV51ART_ID_DOC ;
      private string A4COLONIA ;
      private string AV58COLONIA ;
      private string A2ART_ID_DOC ;
      private string A10NOMBRE ;
      private string A9ACT_ID_CARD ;
      private string A12NOMBRE_COLONIA ;
      private string AV35Nombre ;
      private string AV10ACT_ID_CARD ;
      private string AV59NOMBRE_COLONIA ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] P000F2_A7UMAPS ;
      private bool[] P000F2_n7UMAPS ;
      private decimal[] P000F2_A6CLAVES_RUTASRUTA ;
      private bool[] P000F2_n6CLAVES_RUTASRUTA ;
      private string[] P000F2_A1CLAVE_CATASTRAL ;
      private decimal[] P000F3_A3RUTAS_COLONIARUTA ;
      private string[] P000F3_A4COLONIA ;
      private string[] P000F4_A2ART_ID_DOC ;
      private string[] P000F4_A10NOMBRE ;
      private string[] P000F4_A9ACT_ID_CARD ;
      private string[] P000F4_A12NOMBRE_COLONIA ;
      private bool[] P000F4_n12NOMBRE_COLONIA ;
   }

   public class avineta__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000F2;
          prmP000F2 = new Object[] {
          new ParDef("@AV13Clave",GXType.Decimal,18,0)
          };
          Object[] prmP000F3;
          prmP000F3 = new Object[] {
          new ParDef("@CLAVES_RUTASRUTA",GXType.Decimal,18,6){Nullable=true}
          };
          Object[] prmP000F4;
          prmP000F4 = new Object[] {
          new ParDef("@AV51ART_ID_DOC",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000F2", "SELECT [UMAPS], [RUTA] AS CLAVES_RUTASRUTA, [CLAVE_CATASTRAL] FROM dbo.[CLAVES_RUTAS] WHERE [RUTA] = @AV13Clave ORDER BY [CLAVE_CATASTRAL] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000F3", "SELECT [RUTA] AS RUTAS_COLONIARUTA, [COLONIA] FROM dbo.[RUTAS_COLONIA] WHERE [RUTA] = @CLAVES_RUTASRUTA ORDER BY [RUTA] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P000F4", "SELECT [ART_ID_DOC], [NOMBRE], [ACT_ID_CARD], [NOMBRE_COLONIA] FROM dbo.[MORA] WHERE [ART_ID_DOC] = @AV51ART_ID_DOC ORDER BY [ART_ID_DOC] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F4,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
