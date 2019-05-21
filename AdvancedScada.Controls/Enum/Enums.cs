using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedScada.Controls.Enum
{
    public enum HMITankColorFour
    {
        Blue,
        Green,
        Gray,
        Red,
        Yellow
    }
    public enum HMITankTypeFour
    {
        Type1,
        Type2,
        Type3,
        Type4,
        Type5,
        Type6,
        Type7
    }
    public enum HMITankTypeOne
    {
        TankComp001,
        TankComp002,
        TankComp003,
        TankComp004,
        TankBase001,
        TankBase002,
        TankSmall001,
        TankSmall002,
        TankSmall003,
        TankSmall004Gas,
        TankGas01,
        TankBig002,
        TankBig002a,
        TankBig03sphere,
        TankFunnel001,
        TankFunnel002,
        TankFunnel003,
        TankSewage01,
        TankSewage02,
        TankSewage03,
        TankSewage04,
        TankWater01,
        TankWater02
    }
    public enum HMITankTypeTwo
    {
        TankLibraryListing_Blue,
        TankLibraryListing_Yellow,
        TankLibraryListingWhile
    }
    public enum DAS_BkGradientStyle
    {
        BKGS_Linear,
        BKGS_Linear2,
        BKGS_Polygon,
        BKGS_Sphere,
        BKGS_Sphere2,
        BKGS_Shine
    }
    public enum DAS_BorderGradientStyle
    {
        BGS_None,
        BGS_Flat,
        BGS_Ring,
        BGS_Linear,
        BGS_Linear2,
        BGS_Path
    }
    public enum DAS_BorderStyle
    {
        BS_Rect,
        BS_RoundRect
    }
    public enum DAS_MatrixLEDBordeStyle
    {
        MLBS_None,
        MLBS_Flat,
        MLBS_Raised,
        MLBS_Sunken,
        MLBS_HighRaised,
        MLBS_DeepSunken,
        MLBS_Flat3D,
        MLBS_Ring,
        MLBS_Path,
        MLBS_Linear
    }
    public enum DAS_MatrixLEDShapeStyle
    {
        MLSS_Rect,
        MLSS_RoundRect,
        MLSS_Diamond,
        MLSS_Circle,
        MLSS_Left_Triangle,
        MLSS_Right_Triangle,
        MLSS_Top_Triangle,
        MLSS_Bottom_Triangle
    }
    public enum DAS_ProcessIndicatorType
    {
        PIT_Arrow,
        PIT_Triangle,
        PIT_Squre,
        PIT_Diamond,
        PIT_Circle,
        PIT_Rotation1,
        PIT_Rotation2,
        PIT_Rotation3,
        PIT_Rotation4,
        PIT_Curve,
        PIT_Text,
        PIT_Image,
        PIT_ImageRotation
    }
    public enum DAS_ShapeStyle
    {
        SS_Rect,
        SS_RoundRect,
        SS_Diamond,
        SS_Circle,
        SS_Left_Triangle,
        SS_Right_Triangle,
        SS_Top_Triangle,
        SS_Bottom_Triangle,
        SS_Left_Arrow,
        SS_Right_Arrow,
        SS_Top_Arrow,
        SS_Bottom_Arrow
    }
    public enum DAS_TextPosStyle
    {
        TPS_Left,
        TPS_Right,
        TPS_Top,
        TPS_Bottom,
        TPS_Center
    }
    public enum DAS_ProgressLevelShape
    {
        PLS_Tube,
        PLS_Tube2,
        PLS_Tube3,
        PLS_Funnel,
        PLS_Funnel2,
        PLS_Tank,
        PLS_Tank2,
        PLS_Tank3,
        PLS_Tank4,
        PLS_Tank5,
        PLS_Tank6,
        PLS_Boiler,
        PLS_Boiler2,
        PLS_Cyclinder,
        PLS_Image
    }
    public enum DAS_ProgressImageStyle
    {
        PIS_Img1,
        PIS_Img1_Moving1,
        PIS_Img1_Moving2,
        PIS_Img1_Img2,
        PIS_Img1_Img2_Moving1,
        PIS_Img1_Img2_Moving2,
        PIS_Img1_Img2_Switching1,
        PIS_Img1_Img2_Switching2,
        PIS_Img1_Img2_Img3,
        PIS_Img1_Img2_Img3_Moving1,
        PIS_Img1_Img2_Img3_Moving2,
        PIS_Img1_Img2_Img3_Switching1,
        PIS_Img1_Img2_Img3_Switching2
    }
    public enum DAS_ProgressHeadStyle
    {
        PHS_None,
        PHS_Round,
        PHS_Triangle,
        PHS_Arrow,
        PHS_Image
    }
    public enum DAS_ProcessBorderStyle
    {
        MBS_None,
        MBS_Flat,
        MBS_Raised,
        MBS_Sunken
    }
    public enum DAS_TickerShapeStyle
    {
        Line,
        Rectangle,
        Solid_Rectangle,
        Triangle,
        Solid_Triangle,
        Circle,
        Solid_Circle,
        Trapezoid,
        Solid_Trapezoid
    }
    public enum DAS_TickerAlignmentStyle
    {
        TAS_Text_Left,
        TAS_Text_Right,
        TAS_Text_LeftRight,
        TAS_Center
    }

    public enum DAS_SegmentStyle
    {
        SS_Ladder,
        SS_TShape,
        SS_Rhomb
    }
    public enum DAS_Segment16Style
    {
        S16S_Ladder,
        S16S_Rhomb
    }
    public enum DAS_LEDSegmentLookupStyle
    {
        LSLS_Standard,
        LSLS_Customized
    }
    public enum DAS_LCDWordWrapType
    {
        LWWT_None,
        LWWT_WordWrap1,
        LWWT_WordWrap2,
        LWWT_WordWrap3
    }
    public enum DAS_LCDMatrixStyle
    {
        LCDMS_5x7,
        LCDMS_5x8,
        LCDMS_6x9,
        LCDMS_7x8
    }
    public enum DAS_LCDDotStyle
    {
        LCDDS_Circle,
        LCDDS_Squre,
        LCDDS_Diamond,
        LCDMS_LeftTriangle,
        LCDMS_RightTriangle,
        LCDMS_TopTriangle,
        LCDMS_BottomTriangle
    }
    public enum DAS_LCDCharTextMode
    {
        LCTM_SingleText,
        LCTM_TwoText,
        LCTM_MultiLineConfiguration
    }
    public enum DAS_LCDCharLookupStyle
    {
        LCLS_Standard,
        LCLS_Customized
    }
    public enum DAS_DisplayStyle
    {
        DS_Hex_Style,
        DS_Dec_Style,
        DS_Oct_Style,
        DS_Bin_Style,
        DS_TimeAP_Style,
        DS_Time24_Style,
        DS_Date1_Style,
        DS_Date2_Style,
        DS_TimeAP_Date1_Style,
        DS_TimeAP_Date2_Style,
        DS_Time24_Date1_Style,
        DS_Time24_Date2_Style
    }
}
