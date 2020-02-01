public class MachankoHandler : MonoBehaviour
{
    void Awake(){
        HandTracker.OnMachanko += Bless;
    }

    void Bless(int force){
        
    }
}