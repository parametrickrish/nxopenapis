using System;
using NXOpen;

public class NXJournal
{
    public static void Main(string[] args)
    {
        NXOpen.Session theSession = NXOpen.Session.GetSession();
        NXOpen.Part workPart = theSession.Parts.Work;
        NXOpen.Part displayPart = theSession.Parts.Display;
        
      
        NXOpen.Features.Feature nullNXOpen_Features_Feature = null;
        
        NXOpen.Assemblies.Component component1 = (NXOpen.Assemblies.Component)workPart.ComponentAssembly.RootComponent.FindObject("COMPONENT bar 1");
        NXOpen.PartLoadStatus partLoadStatus1;
        theSession.Parts.SetWorkComponent(component1, NXOpen.PartCollection.RefsetOption.Entire, NXOpen.PartCollection.WorkComponentOption.Visible, out partLoadStatus1);

        workPart = theSession.Parts.Work; // bar
        partLoadStatus1.Dispose();
       
        NXOpen.Features.WaveLinkBuilder waveLinkBuilder2;
        waveLinkBuilder2 = workPart.BaseFeatures.CreateWaveLinkBuilder(nullNXOpen_Features_Feature);

        NXOpen.Features.ExtractFaceBuilder extractFaceBuilder2;
        extractFaceBuilder2 = waveLinkBuilder2.ExtractFaceBuilder;



        waveLinkBuilder2.Type = NXOpen.Features.WaveLinkBuilder.Types.BodyLink;

        extractFaceBuilder2.FaceOption = NXOpen.Features.ExtractFaceBuilder.FaceOptionType.FaceChain;

  

        extractFaceBuilder2.ParentPart = NXOpen.Features.ExtractFaceBuilder.ParentPartType.OtherPart;


        extractFaceBuilder2.Associative = true;

        extractFaceBuilder2.MakePositionIndependent = false;

        extractFaceBuilder2.FixAtCurrentTimestamp = false;

        extractFaceBuilder2.HideOriginal = false;

        extractFaceBuilder2.InheritDisplayProperties = false;

        NXOpen.ScCollector scCollector2;
        scCollector2 = extractFaceBuilder2.ExtractBodyCollector;

        extractFaceBuilder2.CopyThreads = true;

        extractFaceBuilder2.FeatureOption = NXOpen.Features.ExtractFaceBuilder.FeatureOptionType.OneFeatureForAllBodies;

        NXOpen.Body[] bodies1 = new NXOpen.Body[1];
        NXOpen.Assemblies.Component component2 = (NXOpen.Assemblies.Component)displayPart.ComponentAssembly.RootComponent.FindObject("COMPONENT handle 1");
        NXOpen.Body body1 = (NXOpen.Body)component2.FindObject("PROTO#.Bodies|EXTRUDE(2)");
        bodies1[0] = body1;
        NXOpen.BodyDumbRule bodyDumbRule1;
        bodyDumbRule1 = workPart.ScRuleFactory.CreateRuleBodyDumb(bodies1, true);

        NXOpen.SelectionIntentRule[] rules1 = new NXOpen.SelectionIntentRule[1];
        rules1[0] = bodyDumbRule1;
        scCollector2.ReplaceRules(rules1, false);
        
        NXOpen.NXObject nXObject1;
        nXObject1 = waveLinkBuilder2.Commit();

           
        waveLinkBuilder2.Destroy();

        
    }
    public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}

