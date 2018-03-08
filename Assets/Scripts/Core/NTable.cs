using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NTable : UITable {

    protected static Dictionary<string, List<SpriteInfo>> spriteInfos = new Dictionary<string, List<SpriteInfo>>();
    protected int poolObjectLength;

    protected override void Start()
    {        
        spriteInfos = Nglobal.InitSpriteList();
        CaculateLength();
    }

    public new void Reposition()
    {
        if (Application.isPlaying && !mInitDone && NGUITools.GetActive(this)) Init();

        mReposition = false;
        Transform myTrans = transform;
        List<Transform> ch = GetChildList();
        if (ch.Count > 0) RepositionVariableSize(ch);

        if (keepWithinPanel && mPanel != null)
        {
            mPanel.ConstrainTargetToBounds(myTrans, true);
            UIScrollView sv = mPanel.GetComponent<UIScrollView>();
            if (sv != null) sv.UpdateScrollbars(true);
        }

        if (onReposition != null)
            onReposition();
    }

    public virtual void SetCellInfo(Transform myTrans)
    {
        for (int i = 0; i < myTrans.childCount; i++)
        {
            Transform trans = myTrans.GetChild(i);
        }
    }

    private void CaculateLength()
    {
        foreach (var spriteInfo in spriteInfos)
        {
            Debug.Log(spriteInfo); 
        }
    }
}
