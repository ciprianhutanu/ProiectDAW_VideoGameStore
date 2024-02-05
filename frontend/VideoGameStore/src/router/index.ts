import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import HomePage from "@/views/HomePage.vue";
import LoginView from "@/views/LoginView.vue";
import Register from "@/views/Register.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: LoginView
    },
    {
      path: '/HomePage',
      name: 'HomePage',
      component: HomePage,
      // beforeEnter: (to, from, next) => {
      //
      //   const token = localStorage.getItem('MyToken');
      //
      //   if (token) {
      //     next();
      //   } else {
      //     next('/LoginPage');
      //   }
      // }
    },
    {
      path:'/LoginPage',
      name:'LoginPage',
      component: LoginView
    },
    {
      path:'/Register',
      name: 'Register',
      component: Register
    }
  ]
})

export default router
