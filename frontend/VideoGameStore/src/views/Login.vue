<template>
  <div>
    <h2>Login</h2>
    <form @submit.prevent="login">
      <label for="username">Username:</label>
      <input type="text" v-model="username" required />

      <label for="password">Password:</label>
      <input type="password" v-model="password" required />

      <button type="submit">Login</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      username: '',
      password: ''
    };
  },
  methods: {
    login() {
      // Perform authentication logic here
      // For simplicity, we'll just log the credentials for now
      console.log('Username:', this.username);
      console.log('Password:', this.password);

      // You should implement actual authentication here, e.g., API request to a server
    }
  }
};
</script>

<style scoped>
/* Add your styles here if needed */
</style>