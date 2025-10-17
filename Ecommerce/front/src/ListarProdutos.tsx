import { useEffect } from "react";

function ListarProdutos() {
    useEffect(() => {
        console.log("O componente foi carregado!");
        buscarProdutosAPI();
        
    }, []);

    async function buscarProdutosAPI(){
        try {
             const resposta = await fetch ("http://localhost:5257/api/produtos/listar") ;
    console.log(resposta);
    if(resposta.ok){
        throw new Error("Erro na requisição:"+resposta.statusText);
    }
    const dados = await resposta.json();
    console.log(dados);
        } catch (error) {
            console.log(error);
             }
     }

    return (
    <div id = "listar-produtos">
      <h1>Listar Produtos</h1>

    </div>
  );
}
export default ListarProdutos;