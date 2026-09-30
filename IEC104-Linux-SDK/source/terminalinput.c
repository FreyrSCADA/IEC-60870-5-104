
/* ***************************************************************************
 *
 *                          terminalInput.C
 *
 * Based on the work of W. Richard Stevens in "Advanced Programming in
 *   the Unix Environment," Addison-Wesley; and of Floyd Davidson.
 *
 * Contains these functions:
 *
 *  To set the TTY mode:
 *     tty_set_raw() Unix setup to read a character at a time.
 *     tty_set_cooked() Unix setup to reverse tty_set_raw()
 *
 *  To read keyboard input:
 *     kb_getc()      keyboard get character, NON-BLOCKING. If a char
 *                      has been typed, return it. Else return 0.
 *     kb_getc_w()    kb get char with wait: BLOCKING. Wait for a char
 *                      to be typed and return it.
 *
 *  How to use:
 *     tty_set_raw()  set the TTY mode to read one char at a time.
 *     kb_getc()      read chars one by one.
 *     tty_set_cooked() VERY IMPORTANT: restore cooked mode when done.
 *
 * Revision History:
 *
 *     DATE                  DESCRIPTION
 * -----------    --------------------------------------------
 * 12-jan-2002     new
 * 20-aug-2002     cleanup
 * 24-nov-2003     Fixed kb_getc() so that it really is non blocking(JH)
 * 10-sep-2006     Let kb_getc() work right under certain Unix/Linux flavors
 *
 *************************************************************************** */


#ifdef __cplusplus
  extern "C" {
#endif

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <termios.h>
#include <unistd.h>
#include <errno.h>
#include "terminalinput.h"

#ifndef STDIN_FILENO
  #define STDIN_FILENO 0
#endif

//extern int errno;

static struct termios termattr, save_termattr;
static int ttysavefd = -1;
static enum
{
  RESET, RAW, CBREAK
} ttystate = RESET;

/* ***************************************************************************
 *
 * set_tty_raw(), put the user's TTY in one-character-at-a-time mode.
 * returns 0 on success, -1 on failure.
 *
 *************************************************************************** */
int
set_tty_raw(void)
{
  int i;

  i = tcgetattr (STDIN_FILENO, &termattr);
  if (i < 0)
  {
    printf("tcgetattr() returned %d for fildes=%d\n",i,STDIN_FILENO);
    perror ("");
    return -1;
  }
  save_termattr = termattr;

  termattr.c_lflag &= ~(ECHO | ICANON | IEXTEN | ISIG);
  termattr.c_iflag &= ~(BRKINT | ICRNL | INPCK | ISTRIP | IXON);
  termattr.c_cflag &= ~(CSIZE | PARENB);
  termattr.c_cflag |= CS8;
  termattr.c_oflag &= ~(OPOST);

  termattr.c_cc[VMIN] = 1;  /* or 0 for some Unices;  see note 1 */
  termattr.c_cc[VTIME] = 0;

  i = tcsetattr (STDIN_FILENO, TCSANOW, &termattr);
  if (i < 0)
  {
    printf("tcsetattr() returned %d for fildes=%d\n",i,STDIN_FILENO);
    perror("");
    return -1;
  }

  ttystate = RAW;
  ttysavefd = STDIN_FILENO;

  return 0;
}

/* ***************************************************************************
 *
 * set_tty_cbreak(), put the user's TTY in cbreak mode.
 * returns 0 on success, -1 on failure.
 *
 *************************************************************************** */
int
set_tty_cbreak(void)
{
  int i;

  i = tcgetattr (STDIN_FILENO, &termattr);
  if (i < 0)
  {
    printf("tcgetattr() returned %d for fildes=%d\n",i,STDIN_FILENO);
    perror ("");
    return -1;
  }

  save_termattr = termattr;

  termattr.c_lflag &= ~(ECHO | ICANON);
  termattr.c_cc[VMIN] = 1;
  termattr.c_cc[VTIME] = 0;

  i = tcsetattr (STDIN_FILENO, TCSANOW, &termattr);
  if (i < 0)
  {
    printf("tcsetattr() returned %d for fildes=%d\n",i,STDIN_FILENO);
    perror ("");
    return -1;
  }
  ttystate = CBREAK;
  ttysavefd = STDIN_FILENO;

  return 0;
}

/* ***************************************************************************
 *
 * set_tty_cooked(), restore normal TTY mode. Very important to call
 *   the function before exiting else the TTY won't be too usable.
 * returns 0 on success, -1 on failure.
 *
 *************************************************************************** */
int
set_tty_cooked(void)
{
  int i;
  if (ttystate != CBREAK && ttystate != RAW)
  {
    return 0;
  }
  i = tcsetattr (STDIN_FILENO, TCSAFLUSH, &save_termattr);
  if (i < 0)
  {
    return -1;
  }
  ttystate = RESET;
  return 0;
}

/* ***************************************************************************
 *
 * kb_getc(), if there's a typed character waiting to be read,
 *   return it; else return 0.
 * 10-sep-2006: kb_getc() fails (it hangs on the read() and never returns
 * until a char is typed) under some Unix/Linux versions: ubuntu, suse, and
 * maybe others. To make it work, please uncomment two source lines below.
 *
 *************************************************************************** */
unsigned char
kb_getc(void)
{
  int i;
  unsigned char ch;
  ssize_t size;
 termattr.c_cc[VMIN] = 0;  /* uncomment if needed */
  i = tcsetattr (STDIN_FILENO, TCSANOW, &termattr);
  size = read (STDIN_FILENO, &ch, 1);
 termattr.c_cc[VMIN] = 1; /* uncomment if needed */
  i = tcsetattr (STDIN_FILENO, TCSANOW, &termattr);
  if (size == 0)
  {
    return 0;
  }
  else
  {
    return ch;
  }
  return i ;
}

/* ***************************************************************************
 *
 * kb_getc_w(), wait for a character to be typed and return it.
 *
 *************************************************************************** */
unsigned char
kb_getc_w(void)
{
  unsigned char ch;
  size_t size;

  while (1)
  {

    usleep(20000);        /* 1/50th second: thanks, Floyd! */

    size = read (STDIN_FILENO, &ch, 1);
    if (size > 0)
    {
      break;
    }
  }
  return ch;
}
