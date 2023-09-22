public class IntegerIndexer
{
    private int currentIndex = 0;
    private int maxIndex = 0;

    public IntegerIndexer(int maxIndex) {
        this.maxIndex = maxIndex;
    }

    public int GetNextIndex() {
        var probablyNewCurrentIndex = currentIndex + 1;
        currentIndex = IsOutOfRange(probablyNewCurrentIndex) ? 0 : probablyNewCurrentIndex;
        
        return currentIndex;
    }
    
    public bool IsOutOfRange(int index) {
        if (index >= maxIndex)
            return true;
        if (index < 0)
            return true;
        
        return false;
    }
}
