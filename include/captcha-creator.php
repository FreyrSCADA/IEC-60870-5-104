<?PHP

class FGCaptchaCreator extends FG_CaptchaHandler
{
    var $image;
    var $width;
    var $height;
    var $margin_y;
    var $charset;
    var $nChars;
    var $linecolor;
    var $code;
    var $show_captcha_var;
    var $nlines;
    var $enc_key;
    var $captcha_var_name;

    function FGCaptchaCreator($captcha_var_name)
    {
        $this->width = 150;
        $this->height= 60;
        $this->charset="2356789ABCDEFGHJKLMNPQRSTUVWXYZ";
        $this->nChars=6;
        $this->margin_y = 10;

        $this->nlines = 2;
        $this->font_file = 'include/SFOldRepublicSCBold.ttf';
        $this->enc_key="GhsnR5^Hyhsfg";
        $this->captcha_var_name = $captcha_var_name;
    }

    function Validate()
    {
        return $this->ValidateCaptcha($_POST[$this->captcha_var_name]);
    }

    function GetError()
    {
        return 'The code does not match. Please enter the code in the image';
    }


    function SetFontFile($font_file)
    {
        $this->font_file = $font_file;
    }

    function SetNLines($nlines)
    {
        $this->nlines = $nlines;
    }

    function SetSize($width,$height)
    {
      $this->width = $width;
      $this->height= $height;
    }

    function SetCharset($charset)
    {
        $this->charset= $charset;
    }

    function SetNChars($nChars)
    {
        $this->nChars = $nChars;
    }

    function SetEncKey($key)
    {
        $this->enc_key= $key;
    }

    function getSessionVarName()
    {
        $rand = md5('Hgsgst'.$this->GetEncKey());
        return $rand;
    }

    function DisplayCaptcha()
    {
        $this->Create();
        $session_var = $this->getSessionVarName();
        $_SESSION[$session_var] = $this->getCaptchaPwd($this->code);

        $this->ShowCaptcha();
    }

    function getCaptchaPwd($code)
    {
        $code = trim($code);

        $upd_code = strtoupper($code).$this->GetEncKey();

        return md5($upd_code);
    }

    function Create()
    {
        $this->image = imagecreate($this->width, $this->height);
        imagecolorallocate($this->image, 255, 255, 255);

        $this->code = $this->CreateCode();
        return true;
    }

    function ShowCaptcha()
    {
        $this->DrawChars($this->code);
        $this->DrawLines();
        $this->image = $this->Blur($this->image);
        $this->image = $this->Distort($this->image);
        $this->SendImage();
    }

    function ValidateCaptcha($userscode)
    {
        $enc_user_answer = $this->getCaptchaPwd($userscode);
        $session_var = $this->getSessionVarName();
        if($_SESSION[$session_var] == $enc_user_answer)
        {
            return true;
        }
        return false;
    }

    function CreateCode()
    {
        $code = "";
        for($c=0;$c<$this->nChars;$c++)
        {
         $rnum = rand(0,strlen($this->charset)-1);
         $code .= mb_substr($this->charset, $rnum, 1,'UTF-8');
        }
        return $code;
    }

    function DrawLines()
    {
        $width = imagesx($this->image);
        $height = imagesy($this->image);
        $linecolor = imagecolorallocate($this->image,
               $this->linecolor, $this->linecolor, $this->linecolor);
        for($i=0;$i < $this->nlines;$i++)
        {
            $y1=rand(5,$height-5);
            $y2=rand(5,$height-5);
            imageline($this->image,0,$y1,$width,$y2,$linecolor );
        }
    }

    function calculateTextBox($font_size, $font_angle, $font_file, $text)
    {
        $box = imagettfbbox($font_size, $font_angle, $font_file, $text);

        $min_x = min(array($box[0], $box[2], $box[4], $box[6]));
        $max_x = max(array($box[0], $box[2], $box[4], $box[6]));
        $min_y = min(array($box[1], $box[3], $box[5], $box[7]));
        $max_y = max(array($box[1], $box[3], $box[5], $box[7]));

        return array(
            'left' => ($min_x >= -1) ? -abs($min_x + 1) : abs($min_x + 2),
            'top' => abs($min_y),
            'width' => $max_x - $min_x,
            'height' => $max_y - $min_y,
            'box' => $box
        );
    }

    function DrawChars($code)
    {
        $spacing = (int)($this->width / $this->nChars);
        $fontidx=0;

        $N=strlen($code);
        for ($i = 0; $i < $N; $i++)
        {
            $font_size = 25;
            $angle = rand(-30,30);

            $tbox = $this->calculateTextBox($font_size,$angle,$this->font_file,mb_substr($code, $i, 1,'UTF-8'));

            $left = $tbox['left'];
            $top = $tbox['top'];
            $charwidth  = $tbox['width'];

            $charheight = $tbox['height']+rand(0,10);


            $image_char = imagecreate($charwidth,$charheight);
            $bg = imagecolorallocate($image_char, 255, 255, 255);
            ImageColorTransparent($image_char,$bg);

            $coloridx = rand(0, 30);
            $textcolor = imagecolorallocate($image_char, $coloridx, $coloridx, $coloridx);

            if($i==$N/2)
            {
                $this->linecolor=$coloridx;
            }

            $x = $left < 0? abs($left):0;
            if(!imagettftext($image_char, $font_size, $angle, $left, $top,
                    $textcolor, $this->font_file , mb_substr($code, $i, 1,'UTF-8')))
            {
                $this->logger->LogError("imagettftext failed");
            }

            $dispwidth = $spacing - 3;
            $y = ($this->margin_y/2);
            $dispheight = $this->height - $y;

            imagecopyresampled($this->image, $image_char, $i*$spacing, $y, 0, 0,
            $dispwidth, $dispheight, $charwidth, $charheight);
        }
    }

   function Blur($im)
   {
      $width = imagesx($im);
      $height = imagesy($im);

      $imgTmp = ImageCreateTrueColor($width,$height);
      $bg = ImageColorAllocate($imgTmp,255,255,255);
      ImageColorTransparent($imgTmp,$bg);
      ImageFill($imgTmp,0,0,$bg);
      $d = 1;

      ImageCopyMerge($imgTmp, $im, 0, 0, 0, $d, $width, $height-$d, 70);
      ImageCopyMerge($im, $imgTmp, 0, 0, $d, 0, $width-$d, $height, 70);
      ImageCopyMerge($imgTmp, $im, 0, $d, 0, 0, $width, $height, 70);
      ImageCopyMerge($im, $imgTmp, $d, 0, 0, 0, $width, $height, 70);

      ImageDestroy($imgTmp);

      return $im;
   }

   function Distort($im)
   {
      $width = imagesx($im);
      $height = imagesy($im);

      $image_out = ImageCreateTrueColor($width,$height);
      $bg = ImageColorAllocate($image_out,255,255,255);
      ImageFill($image_out,0,0,$bg);


      for($x=0;$x < $width;$x++)
      {
         $peak=$width/4;
         $y = $this->margin_y;

         $d = $y * sin(((double)$x)/$peak);

         imagecopyresampled($image_out, $im, $x, $d, $x, 0,
            1, $height-$d, 1, $height);
      }//for
      return $image_out;
   }

   function SendImage()
   {
      header('Content-type: image/png');

      imagepng($this->image);
   }

   function GetEncKey()
   {
        return $this->enc_key.$_SERVER['SERVER_NAME'].$_SERVER['REMOTE_ADDR'];
   }
}

?>