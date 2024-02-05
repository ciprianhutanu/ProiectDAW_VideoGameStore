<template>
  <div class="auth-container">
    <h2>Register</h2>
    <form @submit.prevent="register" class="auth-form">
      <label for="username">Username:</label>
      <input type="text" v-model="username" required />

      <label for="password">Password:</label>
      <input type="password" v-model="password" required />

      <label for="email">Email:</label>
      <input type="email" v-model="email" required />

      <label for="firstName">First Name:</label>
      <input type="text" v-model="firstName" required />

      <label for="lastName">Last Name:</label>
      <input type="text" v-model="lastName" required />

      <button type="submit" class="auth-button">Register</button>
    </form>

    <router-link to="/LoginPage" class="auth-link">Already have an account? Login here.</router-link>
  </div>
</template>

<script>
import { defineComponent, ref } from 'vue';
import { register as authServiceRegister } from "@/Helpers/Axios";
import router from "@/router";

export default defineComponent({
  name: 'RegisterPage',
  setup() {
    const username = ref('');
    const password = ref('');
    const email = ref('');
    const firstName = ref('');
    const lastName = ref('');

    const register = async () => {
      try {
        await authServiceRegister({
          username: username.value,
          password: password.value,
          email: email.value,
          firstName: firstName.value,
          lastName: lastName.value,
        });

        router.push('/LoginPage');
      } catch (error) {
        console.error('Error during registration:', error);
      }
    };

    return { username, password, email, firstName, lastName, register };
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
  background-color: #008CBA;
  color: white;
  padding: 10px;
  cursor: pointer;
  border: none;
  border-radius: 4px;
}

.auth-link {
  color: #008CBA;
  margin-top: 10px;
  display: block;
}
</style>
