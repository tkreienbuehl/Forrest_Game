public class Influences {

    private short industrialInfluence;
    private short environmentalInfluence;
    private short touristicInfluence;

    public Influences() {
        industrialInfluence = 0;
        environmentalInfluence = 0;
        touristicInfluence = 0;
    }

    public void setIndustrialInfluence(short influence) {
        industrialInfluence = influence;
    }

    public short getIndustrialInfluence() {
        return industrialInfluence;
    }

    public void setEnvironmentalInfluence(short influence) {
        industrialInfluence = influence;
    }

    public short getEnvironmentalInfluence() {
        return environmentalInfluence;
    }

    public void setTouristicalInfluence(short influence) {
        touristicInfluence = influence;
    }

    public short getTouristicalInfluence() {
        return touristicInfluence;
    }

}
