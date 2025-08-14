import React from 'react';
import './ProductList.css';

function ProductList({ products = [], isLoading, error }) {
  if (isLoading) {
    return <p className="loading">Carregando produtos...</p>;
  }

  if (error && !products.length) {
    return <p className="error">{error}</p>;
  }

  return (
    <div className="product-list">
      <table>
        <thead>
          <tr>
            <th>Nome</th>
            <th>Preço</th>
            <th>Categoria</th>
          </tr>
        </thead>
        <tbody>
          {products.length > 0 ? (
            products.map((product) => (
              <tr key={product.id}>
                <td>{product.name}</td>
                <td>R$ {product.price.toFixed(2).replace('.', ',')}</td>
                <td>{product.category}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="3" className="empty">
                Nenhum produto cadastrado ainda.
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
}

export default ProductList;
