import React from 'react';
import './ProductForm.css';

function ProductForm({ name, setName, price, setPrice, category, setCategory, handleSubmit }) {
  return (
    <div className="product-form-container">
      <h2>Novo Produto</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="name">Nome</label>
          <input
            type="text"
            id="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            placeholder="Ex: Teclado Mecânico"
            required
          />
        </div>
        <div>
          <label htmlFor="price">Preço</label>
          <input
            type="number"
            id="price"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
            placeholder="Ex: 350.50"
            step="0.01"
            required
          />
        </div>
        <div>
          <label htmlFor="category">Categoria</label>
          <input
            type="text"
            id="category"
            value={category}
            onChange={(e) => setCategory(e.target.value)}
            placeholder="Ex: Periféricos"
            required
          />
        </div>
        <button type="submit">Cadastrar Produto</button>
      </form>
    </div>
  );
}

export default ProductForm;
