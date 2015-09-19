﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

/// <summary>
/// ImageHelper 的摘要说明
/// </summary>
public class ImageHelper
{
	static ImageHelper()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
    }

    //取图片名称不含扩展名
    public static string GetImageName(string path)
    {
        string imageName = "";

        try
        {
            imageName = Path.GetFileNameWithoutExtension(path);
        }
        catch
        {
        }

        return imageName;
    }

    //取图片名称含扩展名
    public static string GetImageFullName(string path)
    {
        string imageName = "";

        try
        {
            imageName = Path.GetFileName(path);
        }
        catch
        {
        }

        return imageName;
    }

    //取图片扩展名不含点
    public static string GetImageExt(string path)
    {
        string extName = "";

        try
        {
            extName = Path.GetExtension(path);
        }
        catch
        {
        }

        return extName;
    }

    //保存图片，并修改大小。
    public static void SaveImage(string fromFile, double newWidth, double newHeight)
    {
        try
        {
            System.Drawing.Image myimage = System.Drawing.Image.FromStream(new MemoryStream(File.ReadAllBytes(fromFile)));

            double oldWidth = myimage.Width;
            double oldHeight = myimage.Height;

            if (oldWidth > newWidth || oldHeight > newHeight)
            {
                if (myimage.Width >= myimage.Height)
                {
                    oldHeight = newHeight;
                    oldWidth = newHeight / myimage.Height * myimage.Width;
                }
                else
                {
                    oldWidth = newWidth;
                    oldHeight = newWidth / myimage.Width * myimage.Height;
                }
            }

            System.Drawing.Size mysize = new System.Drawing.Size((int)oldWidth, (int)oldHeight);
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(mysize.Width, mysize.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(System.Drawing.Color.Transparent);
            g.DrawImage(myimage, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), new System.Drawing.Rectangle(0, 0, myimage.Width, myimage.Height), System.Drawing.GraphicsUnit.Pixel);

            bitmap.Save(fromFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            g.Dispose();
            bitmap.Dispose();
            myimage.Dispose();
        }
        catch { }
    }

    //另存图片，并修改大小。
    public static void SaveImage(string fromFile, string toFile, double newWidth, double newHeight)
    {
        try
        {
            System.Drawing.Image myimage = System.Drawing.Image.FromStream(new MemoryStream(File.ReadAllBytes(fromFile)));

            double oldWidth = myimage.Width;
            double oldHeight = myimage.Height;

            if (oldWidth > newWidth || oldHeight > newHeight)
            {
                if (myimage.Width >= myimage.Height)
                {
                    oldHeight = newHeight;
                    oldWidth = newHeight / myimage.Height * myimage.Width;
                }
                else
                {
                    oldWidth = newWidth;
                    oldHeight = newWidth / myimage.Width * myimage.Height;
                }
            }

            System.Drawing.Size mysize = new System.Drawing.Size((int)oldWidth, (int)oldHeight);
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(mysize.Width, mysize.Height);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(System.Drawing.Color.Transparent);
            g.DrawImage(myimage, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), new System.Drawing.Rectangle(0, 0, myimage.Width, myimage.Height), System.Drawing.GraphicsUnit.Pixel);

            bitmap.Save(toFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            g.Dispose();
            bitmap.Dispose();
            myimage.Dispose();
        }
        catch { }
    }

}