using System;
using SQLite;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace App3
{
    public class Foundation
    {
        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }
        public int? FoundationID { get; set; }
        public String TrackUnit { get; set; }
        public String TrackLocation { get; set; }
        public Decimal? PlannedNorthing { get; set; }
        public Decimal? PlannedEasting { get; set; }
        public Decimal? PlannedRecos { get; set; }
        public Decimal? PlannedBearing { get; set; }
        public Decimal? PlannedLevel { get; set; }
        public Decimal? PlannedOverallDepth { get; set; }
        public String PlannedExcavationDim { get; set; }
        public Decimal? ActualNorthing { get; set; }
        public Decimal? ActualEasting { get; set; }
        public Decimal? ActualRecos { get; set; }
        public Decimal? ActualBearing { get; set; }
        public Decimal? ActualLevel { get; set; }
        public Decimal? ActualOveralDepth { get; set; }
        public String ActualExcavationDim { get; set; }
        public Decimal? WaterTableLevel { get; set; }
        public Decimal? BoltProjection { get; set; }
        public Decimal? NonEffectiveDepth { get; set; }
        public Boolean? Orienation { get; set; }
        public Boolean? ReBarCorrectlyInstalled { get; set; }
        public DateTime? InstallationDate { get; set; }
        public String PermitToDigIssued { get; set; }
        public String TestCubeReference { get; set; }
        public Boolean? FoundationAcceptable { get; set; }
        public String Comments { get; set; }
        public Decimal? ActualOverallDepthMiniPile1 { get; set; }
        public Decimal? ActualOverallDepthMiniPile2 { get; set; }
        public Decimal? ActualOverallDepthMiniPile3 { get; set; }
        public Decimal? ActualOverallDepthMiniPile4 { get; set; }
        public Decimal? ActualOverallDepthMiniPile5 { get; set; }
        public Decimal? ActualOverallDepthMiniPile6 { get; set; }
        public Boolean? AllocationOfBinders { get; set; }
        public Boolean? ConfirmMiniPile1Dimension { get; set; }
        public Boolean? ConfirmMiniPile2Dimension { get; set; }
        public Boolean? ConfirmMiniPile3Dimension { get; set; }
        public Boolean? ConfirmMiniPile4Dimension { get; set; }
        public Boolean? ConfirmMiniPile5Dimension { get; set; }
        public Boolean? ConfirmMiniPile6Dimension { get; set; }
        public int? ExcavationType { get; set; }
        public Boolean? OrientationAlongTrack { get; set; }
        public Boolean? OrientationPerpendicular { get; set; }
        public int? PileHeadHits { get; set; }
        public Boolean? ShutterRemovalAcceptable { get; set; }
        public Boolean? WorksCompletionAccetable { get; set; }
        public String AllocationsList { get; set; }
        public String AllocatedList { get; set; }
        public String Chainage { get; set; }
        public String StructureNo { get; set; }
        public int? StructureNoID { get; set; }
        public int? WireRunID { get; set; }
        public String EngineerName { get; set; }
        public Byte[] EngineerSignature { get; set; }
        public DateTime? EngineerDate { get; set; }
        public String SupervisorName { get; set; }
        public Byte[] SupervisorImage { get; set; }
        public DateTime? SupervisorDate { get; set; }
        public DateTime? BaseLineInstallationDate { get; set; }
        public DateTime? PlannedInstallationDate { get; set; }
        public int? ActualAllocationID { get; set; }
        public Decimal? PlannedBoltProjection { get; set; }
        public int? PlannedAllocationID { get; set; }
        public Decimal? PlannedEffectiveDepth { get; set; }
        public Decimal? PlannedNonEffectiveDepth { get; set; }
        public Byte[] BoltOrientationSignOff { get; set; }
        public Byte[] ReBarSignOff { get; set; }
        public Byte[] ConstructionMgrSignOff { get; set; }
        public Boolean? WorkSiteTidy { get; set; }
        public Boolean? OutstandingWorks { get; set; }
        public Boolean? RedesignRequired { get; set; }
        public String RedesignComments { get; set; }
        public int? MapToID { get; set; }
        public int? MappingTypeID { get; set; }
        public Decimal? PlannedTopOfRailLevel { get; set; }
        public Decimal? ActualTopOfRailLevel { get; set; }
        public Decimal? PlannedOverallPileLength { get; set; }
        public Decimal? ActualOverallPileLength { get; set; }
        public Decimal? PlannedNoOfSections { get; set; }
        public Decimal? ActualNoOfSections { get; set; }
        public Byte[] RedesignSignOff { get; set; }
        public String Finalcomments { get; set; }
        public Boolean? NcrRaised { get; set; }
        public String NcrComments { get; set; }
        public int? Version { get; set; }
        public DateTime? Created { get; set; }
        public String CreatedBy { get; set; }
        public int? OLEStatusLKID { get; set; }
        public int? OriginalID { get; set; }
        public String TypeDescription { get; set; }
        public int? SortOrder { get; set; }
        public Boolean? WPPComplete { get; set; }
        public Boolean? SettingOutComplete { get; set; }
        public Boolean? BuriedServicesComplete { get; set; }
        public Boolean? TrialHoleComplete { get; set; }
        public Boolean? AFCComplete { get; set; }
        public Boolean? NoOpenTQ { get; set; }
        public String ColorCode { get; set; }
        public String DrawingRevision { get; set; }
        public String AllocationRevision { get; set; }
        public Decimal? PlannedElevation { get; set; }
        public Decimal? ActualElevation { get; set; }
        public Decimal? PileDiameter { get; set; }
        public Decimal? BoomLength { get; set; }
        public String Revision { get; set; }
        public Decimal? PileElevation { get; set; }
        public Decimal? RailElevation { get; set; }
        public Decimal? RailOffset { get; set; }
        public Decimal? TrackLevel { get; set; }
        public Decimal? TroughLevel { get; set; }
        public Decimal? GroundLevel { get; set; }
        public Decimal? SettingOutRECOS { get; set; }
        public Decimal? DistanceFromTrough { get; set; }
        public String Topography { get; set; }
        public String DeVeg { get; set; }
        public String Obstruction { get; set; }
        public String BuriedServiceComments { get; set; }
        public Boolean? StatusComplete { get; set; }
        public Decimal? FrontFaceProtrusion { get; set; }
        public Decimal? RearFaceProtrusion { get; set; }
        public Decimal? RotationA { get; set; }
        public Decimal? RotationB { get; set; }
        public Decimal? ActualBoomLength { get; set; }
        public Decimal? ActualPileDiameter { get; set; }
        public String TQNumber { get; set; }
        public int? ConstructionStatusID { get; set; }
        public String ConstructionStatusDescription { get; set; }
        public Decimal? SettingOutEasting { get; set; }
        public Decimal? SettingOutNorthing { get; set; }
        public int? PackNoID { get; set; }
        public String PackNo { get; set; }
        public String AllocationCode { get; set; }
        public String Road { get; set; }
        public String Kilometerage { get; set; }
        public Decimal? Mileage { get; set; }
        public Decimal? Yards { get; set; }
        public String ExcavationTypeDescr { get; set; }
        public int? OLEStructureNoMapID { get; set; }

        public string Summary
        {
            
            get {
                Debug.WriteLine("Getting Summary");
                return String.Format("Id: {0}, Added by {1}", ID, EngineerName);}
        }

        public override string ToString()
        {
            var out_string = string.Format("ID: {0},@Engineer Name: {1},@Signature: {2},@Date: {3}", ID, EngineerName, EngineerSignature, EngineerDate);
            out_string.Replace("@", Environment.NewLine);
            return out_string;
        }
    }

    public class FoundationObject
    {
        public Foundation[] foundations { get; set; }
    }
}
