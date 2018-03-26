using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  
public class jingziqi : MonoBehaviour {  
  
    private int turn = 1;   //记录是谁的回合  
    private int[,] state = new int[3,3];    //九方格数据  
  
    //参数初始化  
    void Start() {  
        reset();  
    }  
  
    void OnGUI() {  
        if (GUI.Button(new Rect(420,300,100,50),"Reset"))  
            reset();  
        int result = check();  
        if (result==1) {  
            GUI.Label(new Rect(450,350,100,50),"O方胜利!");
            GUI.Label(new Rect(400,365,150,50),"请按reset重新开始游戏!");
        }  
        else if (result==-1) {  
            GUI.Label(new Rect(450,350,100,50),"X方胜利!");
            GUI.Label(new Rect(400,365,150,50),"请按reset重新开始游戏!");
        }  
        else if (result==2) {  
            GUI.Label(new Rect(450,350,100,50),"平局!");
            GUI.Label(new Rect(400,365,150,50),"请按reset重新开始游戏!");
        }  
        for (int i=0; i<3; ++i) {  
            for (int j=0; j<3; ++j) {  
                if (state[i,j]==1)  
                    GUI.Button(new Rect(400+i*50,100+j*50,50,50),"O");  
                if (state[i,j]==-1)  
                    GUI.Button(new Rect(400+i*50,100+j*50,50,50),"X");  
                if(GUI.Button(new Rect(400+i*50,100+j*50,50,50),"")) {  
                    if (result==0) {  
                        state[i,j] = turn;  
                        turn = -turn;  
                    }  
                }  
            }  
        }  
    }  
  
    //重置参数  
    void reset() {  
        turn = 1;  
        for (int i=0; i<3; ++i) {  
            for (int j=0; j<3; ++j) {  
                state[i,j] = 0;  
            }  
        }  
    }  
  
    //判断游戏结束条件  
    int check() {  
        // 横向连线  
        for (int i=0; i<3; ++i) {  
            if (state[i,0]!=0 && state[i,0]==state[i,1] && state[i,1]==state[i,2]) {  
                return state[i,0];  
            }  
        }  
        //纵向连线  
        for (int j=0; j<3; ++j) {  
            if (state[0,j]!=0 && state[0,j]==state[1,j] && state[1,j]==state[2,j]) {  
                return state[0,j];  
            }  
        }  
        //斜向连线  
        if (state[1,1]!=0 &&  
            state[0,0]==state[1,1] && state[1,1]==state[2,2] ||  
            state[0,2]==state[1,1] && state[1,1]==state[2,0]) {  
            return state[1,1];  
        }  
        for(int i =0; i<3; i++) {
            for(int j=0; j<3; j++) {
                if(state[i,j]==0)
                    return 0;
            }
        }
        return 2;
     }  
}  
