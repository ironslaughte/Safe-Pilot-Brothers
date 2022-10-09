using System;

namespace The_safe_of_the_Pilot_brothers
{
    public static class Utils
    {
        public static bool IsHandleOpened(this SafeModel safe, int i, int j)
            => safe.GetHandle(i, j) == HandleType.OPEN;

        public static HandleType ChangeHandleState(this HandleType handleType) =>
            (handleType == HandleType.CLOSE) ? HandleType.OPEN : HandleType.CLOSE;

        public static (int,int) ParseIndexesPic(string namePic)
        {
            string[] idxPics = namePic.Split(',');
            return (Convert.ToInt32(idxPics[0]), Convert.ToInt32(idxPics[1]));    
        }
    }
}
