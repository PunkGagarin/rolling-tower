public interface IUnitStat<T> {
    public void DecreaseCurrentValue(float value);
    public void IncreaseCurrentValue(float value);
    public T getStatType();

    public float getCurrentValue();
}