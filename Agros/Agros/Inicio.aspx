<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Agros.WebForm1" Title="Untitled Page" %>

<asp:Content runat="server" ContentPlaceHolderID="Editable">


    <form id="form1" runat="server">
    </form>
    
    
    
    	<div id="page">
		<div id="content">
			<div id="banner"><img src="images/img07.jpg" alt="" /></div>
			<div class="post">
				<h2 class="title"><a href="#">Agros es servicios para el campo </a></h2>
				<p class="meta">Agricultura Responsable</p>
				<div class="entry">
					<p>La tierra cultivable es un recurso natural de vital importancia, cada vez más 
                        escaso a nivel mundial.</p>
					<p>Situacion acentuada por el crecimiento de los consumidores de alimentos de alto 
                        valor&nbsp; y una mayor demanda de cereales y oleaginosas para la elaboracion de 
                        biocombustibles.</p>
					<p class="links"><a href="#" class="more">Read More</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" class="comments">Comments (33)</a></p>
				</div>
			</div>
			<div style="clear: both;">&nbsp;</div>
		</div>
		<!-- end #content -->
		<div id="sidebar">
			<ul>
				<li>
					<h2>Plagas al dia</h2>
					<p><strong>Pulgon verde de los cereales</strong> Son insectos diminutos que miden 
                        entre 1,5 y 2 mm de longitud. En la planta se ubican en la base de la misma y en 
                        las hojas. Esta especie puede atacar al cultivo. <a href="#">Mas…</a></p>
				</li>
				<li>
					<h2>Servicios</h2>
					<ul>
						<li><span>01</span><a href="#">Fumigación</a></li>
						<li><span>02</span><a href="#">Riego</a></li>
						<li><span>03</span><a href="#">Fertilización del suelo</a></li>
						<li><span>04</span><a href="#">Manejo de insectos </a></li>
						<li><span>05</span><a href="#">Manejo de malezas </a></li>
						<li><span>06</span><a href="#">Fumigación mosca blanca </a></li>
						<li><span>07</span><a href="#">Control de cosecha </a></li>
						<li><span>08</span><a href="#">Desratización</a></li>
					</ul>
				</li>
			</ul>
		</div>
		<!-- end #sidebar -->
		<div style="clear: both;">&nbsp;</div>
	</div>
	<!-- end #page -->
</div>
<div id="footer-content">
	<div class="column1">
		<h2>Beneficios </h2>
		<p>La agricultura de los ultimos años nos ha demostrado que no hay dos campañas 
            iguales en referencia a la presencia de plagas. A las que ya conocemos, se han 
            sumado la aparición de nuevos insectos, enfermedades de otras regiones que se 
            diseminan a nuestra área y presencia de malezas que ya no son controladas por 
            algunos herbicidas. . <a href="#">Leer mas…</a></p>
	</div>
	<div class="column2">
		<ul class="list">
			<li><a href="#">Trigo mapa con puntos georeferenciados</a> </li>
			<li><a href="#">Soja estado fenológico del cultivo</a></li>
			<li><a href="#">Maiz Las enfermedades provocan una disminución en la producción</a></li>
			<li><a href="#">La identificación y cuantificación de las enfermedades  es fundamental</a></li>
		</ul>
	</div>
</div>
<div id="footer">
	<p> (c) 2012 <a href="#">diseñado por Andrada Leoni</a>.</p>
</div>
<!-- end #footer -->


</asp:Content>