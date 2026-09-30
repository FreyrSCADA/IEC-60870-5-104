/*
 * terminalinput.h
 *
 */

#ifndef TERMINALINPUT_H_
#define TERMINALINPUT_H_

int set_tty_raw(void);
int set_tty_cbreak(void);
int set_tty_cooked(void);
unsigned char kb_getc(void);
unsigned char kb_getc_w(void);

#endif /* TERMINALINPUT_H_ */