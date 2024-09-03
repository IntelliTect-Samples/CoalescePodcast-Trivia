import { createRouter, createWebHistory } from "vue-router";
import { CAdminEditorPage, CAdminTablePage, CAdminAuditLogPage } from "coalesce-vue-vuetify3";

export default createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: "/",
      name: "home",
      component: () => import("./views/Home.vue"),
    },
    {
      path: "/question-summary",
      name: "question-summary",
      component: () => import("./views/QuestionSummary.vue"),
    },
    {
      path: "/questions",
      name: "questions",
      component: () => import("./views/Questions.vue"),
    },
    {
      path: "/question/:id",
      name: "question",
      component: () => import("./views/QuestionEditor.vue"),
      props: (route) => ({ id: route.params.id }),
    },
    {
      path: "/admin",
      name: "admin",
      component: () => import("./views/Admin.vue"),
    },

    // Audit Logs
    {
      path: '/admin/audit-logs',
      component: CAdminAuditLogPage,
      props: { type: 'AuditLog' }
    },

    // Coalesce admin routes
    {
      path: "/admin/:type",
      name: "coalesce-admin-list",
      component: titledAdminPage(CAdminTablePage),
      props: true,
    },
    {
      path: "/admin/:type/edit/:id?",
      name: "coalesce-admin-item",
      component: titledAdminPage(CAdminEditorPage),
      props: true,
    },
  ],
});

/** Creates a wrapper component that will pull page title from the
 *  coalesce admin page component and pass it to `useTitle`.
 */
function titledAdminPage<
  T extends typeof CAdminTablePage | typeof CAdminEditorPage,
>(component: T) {
  return defineComponent({
    setup() {
      const pageRef = ref<InstanceType<T>>();
      useTitle(() => pageRef.value?.pageTitle);
      return { pageRef };
    },
    render() {
      return h(component, {
        color: "primary",
        ref: "pageRef",
        ...this.$attrs,
      });
    },
  });
}
