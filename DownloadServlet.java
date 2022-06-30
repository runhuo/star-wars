package com.lht_tx.finalstarwars;


import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

@WebServlet(name = "DownloadServlet", value = "/DownloadServlet")
public class DownloadServlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        this.doPost(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("application/x-msdownload");
        response.setHeader("Content-Disposition", "attachment;filename=Star Wars.zip");
        String classpath =  this .getClass().getResource( "/" ).getPath().replaceFirst( "/" ,  "" );
        String webappRoot = classpath.replaceAll( "WEB-INF/classes/" ,  "" );
        String filePath=webappRoot+"TemplateData/Star Wars.zip";
        File file = new File(filePath);
        FileInputStream in = new FileInputStream(file);
        ServletOutputStream out = response.getOutputStream();
        byte[] car = new byte[1024];
        int len = 0;
        while((len = in.read(car)) != -1){
            out.write(car,0,len);
        }
        in.close();
        out.close();
    }
}
