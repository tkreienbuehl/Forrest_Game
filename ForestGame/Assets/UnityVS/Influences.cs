public class Influences {

    private byte industrialInfluence;
    private byte environmentalInfluence;
    private byte touristicInfluence;

    public Influences() {
        industrialInfluence = 0;
        environmentalInfluence = 0;
        touristicInfluence = 0;
    }

    public void setIndustrialInfluence(byte influence) {
        industrialInfluence = influence;
    }

    public byte getIndustrialInfluence() {
        return industrialInfluence;
    }

    public void setEnvironmentalInfluence(byte influence) {
        industrialInfluence = influence;
    }

    public byte getEnvironmentalInfluence() {
        return environmentalInfluence;
    }

    public void setTouristicalInfluence(byte influence) {
        touristicInfluence = influence;
    }

    public byte getTouristicalInfluence() {
        return touristicInfluence;
    }

}
