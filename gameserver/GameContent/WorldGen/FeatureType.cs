namespace GameContent.WorldGen;

public abstract class FeatureType
{
    public static FeatureType RuinsAndRelics = new RuinsAndRelicsFeature();
    public static FeatureType LuridLairs = new LuridLairsFeature();
    public static FeatureType RiversAndRoads = new RiversAndRoadsFeature();
    public static FeatureType CastlesAndCitadels = new CastlesAndCitadelsFeature();
    public static FeatureType TemplesAndShrines = new TemplesAndShrinesFeature();
    public static FeatureType VillagesAndTowns = new VillagesAndTownsFeature();
}

public class RuinsAndRelicsFeature : FeatureType {}
public class LuridLairsFeature : FeatureType {}
public class RiversAndRoadsFeature : FeatureType {}
public class CastlesAndCitadelsFeature : FeatureType {}
public class TemplesAndShrinesFeature : FeatureType {}
public class VillagesAndTownsFeature : FeatureType {}