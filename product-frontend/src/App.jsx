import React, { useState, useEffect } from 'react'; 
import Header from './components/Header/Header';
import ProductForm from './components/ProductForm/ProductForm';
import ProductList from './components/ProductList/ProductList';
import './App.css'; 

function App() {
  const [products, setProducts] = useState([]);
  const [name, setName] = useState('');
  const [price, setPrice] = useState('');
  const [category, setCategory] = useState('');
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState('');

  const API_URL = "https://localhost:7105/api/Product"

  const fetchProducts = async () => {
    setIsLoading(true);
    setError('');
    try {
      const res = await fetch(API_URL);
      if (!res.ok) throw new Error(`Falha ao buscar produtos da API`);
      const data = await res.json();
      setProducts(data);
    } catch (err) {
      setError(err.message || 'Erro desconhecido ao buscar produtos.');
    } finally {
      setIsLoading(false);
    }
  };



  useEffect(() => {
    fetchProducts();
  }, []);


  const handleSubmit = async (e) => {
    e.preventDefault();
    
    const newProduct = {
      name,
      price: parseFloat(price),
      category,
    };

    try {
      const res = await fetch(API_URL, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newProduct),
      });

      if (!res.ok) {
        throw new Error('Falha ao cadastrar o produto.');
      }


      setName('');
      setPrice('');
      setCategory('');
      
    
      fetchProducts(); 

    } catch (err) {
      setError(err.message || 'Erro ao cadastrar produto.');
    }
  };

  return (
    <div className="app-container">
      <Header />


      {error && <p className="app-error">{error}</p>}

      <main className="grid-container">
        <ProductForm
          name={name}
          setName={setName}
          price={price}
          setPrice={setPrice}
          category={category}
          setCategory={setCategory}
          handleSubmit={handleSubmit}
        />
        <ProductList 
          products={products} 
          isLoading={isLoading} 
         
        />
      </main>
    </div>
  );
}

export default App;