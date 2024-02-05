<template>
  <div class="auth-container">
    <h2>Login</h2>
    <form @submit.prevent="login" class="auth-form">
      <label for="username">Username:</label>
      <input type="text" v-model="username" required />

      <label for="password">Password:</label>
      <input type="password" v-model="password" required />

      <button type="submit" class="auth-button">Login</button>

      <router-link to="/Register" class="auth-link">Don't have an account? Register here.</router-link>
    </form>
  </div>
</template>

<script>
import { defineComponent, ref } from 'vue';
import {login as authServiceLogin} from "@/Helpers/Axios";
import router from "@/router";

export default defineComponent({
  name: 'LoginPage',
  setup() {
    const username = ref('');
    const password = ref('');

    const login = async () => {
      await authServiceLogin(username.value, password.value);
      console.log(username.value, password.value);
      var token = localStorage.getItem('MyToken');
      if(token){
        router.push('/HomePage');
      }
    };
    return { username, password, login };
  },
});

</script>

<style scoped>
.auth-container {
  max-width: 400px;
  margin: auto;
  text-align: center;
  padding: 20px;
}

.auth-form {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.auth-button {
  background-color: #4caf50;
  color: white;
  padding: 10px;
  cursor: pointer;
  border: none;
  border-radius: 4px;
}

.auth-link {
  color: #4caf50;
  margin-top: 10px;
  display: block;
}
</style>