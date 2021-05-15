//イジらないこと！！

#include "app.h"

//ボタン押下判定関数
void button(char *str, controller* con) {
    for (int i = 0; i < buttonnum; i++) {
        con->button[i] = str[i] - '0';
    }
}

int char_to_int(char s) {
    return 2 * ((int)s - 50);
}

void button_draw(lcd_xy plot, controller con) {
    ev3_lcd_draw_string("SCCTLRLRSOLRPP", plot.x, plot.y); //値名1
    ev3_lcd_draw_string("QRIR1122HPSSSD", plot.x, plot.y + 15); //値名2
    ev3_lcd_draw_string("b:", plot.x - 19, plot.y + 30);
    static char *strb;
    strb = (char*)malloc(sizeof(char) * 15);
    sprintf(strb, "%d%d%d%d%d%d%d%d%d%d%d%d%d%d", 
            con.button[0], con.button[1], con.button[2], con.button[3],
            con.button[4], con.button[5], con.button[6], con.button[7],
            con.button[8], con.button[9], con.button[10], con.button[11],
            con.button[12], con.button[13]);
    ev3_lcd_draw_string(strb, plot.x, plot.y + 32); //読込値描画
    free(strb);
}

void stick_draw(lcd_xy plot, controller con) {
    static char *strs;
    strs = (char*)malloc(sizeof(char) * 20);
    sprintf(strs, "L:X%-4dY%-4dT%-3d", con.left_stick_x, con.left_stick_y, con.left_trigger); //intからstrに型変換(表示用)
    ev3_lcd_draw_string(strs, plot.x, plot.y); //左スティックとL2の値描画
    sprintf(strs, "R:X%-4dY%-4dT%-3d", con.right_stick_x, con.right_stick_y, con.right_trigger); //intからstrに型変換(表示用)
    ev3_lcd_draw_string(strs, plot.x, plot.y + 20); //スティックとR2の値描画
    sprintf(strs, "%3d", con.d_pad); //intからstrに型変換(表示用)
    ev3_lcd_draw_string("POV", plot.x, plot.y - 50);
    ev3_lcd_draw_string(strs, 0, 35); //十字キーの値描画
    free(strs);
}

//チーム名の描画
void teamname_draw(lcd_xy plot, char* teamname) {
    ev3_lcd_draw_string("MadeBy", plot.x, plot.y);
    ev3_lcd_draw_string(teamname, plot.x + 65, plot.y);
}

//シリアル受信と値の割当
int receive(controller* con, FILE *bt){
    //シリアル通信
    static char *str;
    str = (char*)malloc(sizeof(char) * 25);
    if(fgetc(bt) == 'b') {
        fgets(str, 22, bt); //シリアル一行読込
        button(str, con);
        //charからintに型変換
        con->left_trigger = (int)str[LT];
        con->right_trigger = (int)str[RT];
        con->left_stick_x = char_to_int(str[LSX]);
        con->left_stick_y = char_to_int(str[LSY]);
        con->right_stick_x = char_to_int(str[RSX]);
        con->right_stick_y = char_to_int(str[RSY]);
        con->d_pad = (int)str[DPAD] != 0? 3 * ((int)str[DPAD] - 1) : -1;
    }
    free(str);
    return 0;
}