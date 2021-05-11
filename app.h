
#include "target_test.h"
#include "ev3api.h"
#include <stdio.h>
#include <stdlib.h>

#ifndef STACK_SIZE
#define	STACK_SIZE		4096		/* タスクのスタックサイズ */
#endif /* STACK_SIZE */

#ifndef TOPPERS_MACRO_ONLY

extern void	task(intptr_t exinf);
extern void	main_task(intptr_t exinf);
//extern void balance_task(intptr_t exinf);
//extern void idle_task(intptr_t exinf);

#endif /* TOPPERS_MACRO_ONLY */

#ifndef _TOKUDAI_
#define _TOKUDAI_

#define buttonnum 14

//モーターポートの設定
#define A_motor     EV3_PORT_A
#define B_motor     EV3_PORT_B
#define Left_motor  EV3_PORT_C
#define Right_motor EV3_PORT_D

//ここから下はイジらないこと！！
//ボタンの番号の設定
#define SQUARE      0
#define CROSS       1
#define CIRCLE      2
#define TRIANGLE    3
#define L1          4
#define R1          5
#define L2          6
#define R2          7
#define SHARE       8
#define OPTIONS     9
#define L_STICK     10
#define R_STICK     11
#define PS          12
#define PAD         13
//L2･R2押込圧の番号の設定
#define SL2         14
#define SR2         15
//スティック番号の設定
#define SLX         16
#define SLY         17
#define SRX         18
#define SRY         19
//十字キーの番号の設定
#define POV         20

typedef struct controller {
    int button[buttonnum];    
    int left_stick_x;
    int left_stick_y;
    int right_stick_x;
    int right_stick_y;
    int left_trigger;
    int right_trigger;
    int d_pad; 
} controller;

typedef struct lcd_xy {
    int x;
    int y;
} lcd_xy;

//ボタン押下判定関数
static void button(char *str, controller* con);
static int char_to_int(char s);
extern void button_draw(lcd_xy plot, controller con);
extern void stick_draw(lcd_xy plot, controller con);
extern void teamname_draw(lcd_xy plot, char* teamname);
extern int receive(controller* con, FILE *bt);
#endif